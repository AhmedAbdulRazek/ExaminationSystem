using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Examination.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.Repository
{
    public class QuestionTypeRepo : IQuestionTypeRepo
    {
        private readonly ExamContext context;
        public QuestionTypeRepo(ExamContext context)
        {
            this.context = context;
        }

        public IEnumerable<QuestionTypeVM> GetAll()
        {
            var types = context.QuestionTypes.Select(t => new QuestionTypeVM()
            {
                Id = t.Id,
                Type = t.Type
            }).ToList();

            return types;
        }

    }
}
