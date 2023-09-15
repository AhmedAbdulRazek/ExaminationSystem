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
using Microsoft.EntityFrameworkCore;

namespace Examination.BL.Repository
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly DbConnection cN;
        private readonly IConfiguration configuration;
        private readonly ExamContext context;

        public QuestionRepo(IConfiguration configuration, ExamContext context)
        {
            this.configuration = configuration;
            this.context = context;
            cN = new SqlConnection(configuration.GetConnectionString("MyConnection"));
        }
        public IEnumerable<QuestionVM> GetAll()
        {

            var questionsVM = context.Questions.Include(t => t.QuestionType).Select(q => new QuestionVM()
            {
                QuestionId = q.QuestionId,
                QuestionText = q.QuestionText,
                QuestionTypeId = q.QuestionTypeId,
                QuestionTypeName = q.QuestionType.Type,
                Mark = q.Mark,
                ExamId = q.ExamId
            }).ToList();

            return questionsVM;
        }

        public IEnumerable<QuestionVM> GetQuestionsByFirstExamID()
        {

            var exam = context.Exams.Include(e => e.Questions).FirstOrDefault();

            var questions = context.Questions.Include(t => t.QuestionType).Include(s => s.Answers)
                .Where(q => q.ExamId == exam.Id)
                .ToList();



            var questionVMS = new List<QuestionVM>();
            foreach (var item in questions)
            {
                var AnswersVMS = new List<AnswerVM>();
                foreach (var quest in item.Answers)
                {
                    var ans = new AnswerVM()
                    {
                        AnswerId = quest.AnswerId,
                        ProvidedAnswer = quest.ProvidedAnswer,
                        IsCorrect = quest.IsCorrect,
                        QuestionId = quest.QuestionId
                    };

                    AnswersVMS.Add(ans);


                }

                var questionVM = new QuestionVM()
                {
                    QuestionId = item.QuestionId,
                    QuestionText = item.QuestionText,
                    Mark = item.Mark,
                    QuestionTypeId = item.QuestionTypeId,
                    QuestionTypeName = item.QuestionType.Type,
                    ExamId = item.ExamId,
                    Answers = AnswersVMS
                };

                questionVMS.Add(questionVM);
            }

            return questionVMS;

        }
        public IEnumerable<QuestionVM> GetQuestionsByExamID(int id)
        {
            var questionsVM = context.Questions.Include(t => t.QuestionType).Include(s => s.Answers)
                .Where(e => e.ExamId == id)
                .ToList();

            var questionVMS = new List<QuestionVM>();
            foreach (var item in questionsVM)
            {
                var AnswersVMS = new List<AnswerVM>();
                foreach (var quest in item.Answers)
                {
                    var ans = new AnswerVM()
                    {
                        AnswerId = quest.AnswerId,
                        ProvidedAnswer = quest.ProvidedAnswer,
                        IsCorrect = quest.IsCorrect,
                        QuestionId = quest.QuestionId
                    };

                    AnswersVMS.Add(ans);

                    
                }

                var questionVM = new QuestionVM()
                {
                    QuestionId = item.QuestionId,
                    QuestionText = item.QuestionText,
                    Mark = item.Mark,
                    QuestionTypeId = item.QuestionTypeId,
                    QuestionTypeName = item.QuestionType.Type,
                    ExamId = item.ExamId,
                    Answers = AnswersVMS
                };

                questionVMS.Add(questionVM);
            }

            return questionVMS;
           

        }
        public void Create(CreateQuestionVM question)
        {
            
            Question quest = new Question()
            {
                QuestionText = question.QuestionText,
                QuestionTypeId = question.QuestionTypeId,
                Mark = question.Mark,
                ExamId = question.ExamId
            };

            context.Questions.Add(quest);
            context.SaveChanges();
        }

        

        public void Edit(QuestionVM question)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
