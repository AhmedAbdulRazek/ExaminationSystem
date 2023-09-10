using Dapper;
using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Examination.DAL.Context;
using Examination.DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.Repository
{
    public class ExamRepo : IExamRepo
    {
        private readonly DbConnection cN;
        private readonly IConfiguration configuration;
        private readonly ExamContext context;

        public ExamRepo(IConfiguration configuration, ExamContext context)
        {
            this.configuration = configuration;
            this.context = context;
            cN = new SqlConnection(configuration.GetConnectionString("MyConnection"));
           
        }


        public IEnumerable<ExamVM> GetAll()
        {
            var exams = cN.Query<Exam>("SelectAllExams", commandType: System.Data.CommandType.StoredProcedure);

            List<ExamVM> examsVM = new List<ExamVM>();

            foreach (var item in exams)
            {
                examsVM.Add(new ExamVM()
                {
                    Id = item.Id,
                    Subject = item.Subject
                });
            }

            return examsVM;
        }

        public ExamVM GetById(int id)
        {
            Exam exam = cN.QueryFirstOrDefault<Exam>("Select * from Exams where Id = @ExamId", new { ExamId = id });

            ExamVM examVM = new ExamVM()
            {

                Id = exam.Id,
                Subject = exam.Subject
            };

            return examVM;
        }

        public void Create(CreateExamVM exam)
        {
            Exam ex = new Exam()
            {
                Subject = exam.Subject
            };

            context.Exams.Add(ex);
            context.SaveChanges();
        }

        public void Edit(ExamVM exam)
        {
            Exam ex = context.Exams.Find(exam.Id);

            ex.Id = exam.Id;
            ex.Subject = exam.Subject;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Exam ex = context.Exams.Find(id);

            context.Exams.Remove(ex);
            context.SaveChanges();
        }
    }
}
