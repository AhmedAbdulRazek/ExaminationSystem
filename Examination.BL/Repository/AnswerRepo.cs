using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Examination.DAL.Entities;
using Examination.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Examination.BL.Repository
{
    public class AnswerRepo : IAnswerRepo
    {
        
        private readonly ExamContext context;

        public AnswerRepo(ExamContext context)
        {
            
            this.context = context;
            
        }

        public IEnumerable<AnswerVM> GetAll()
        {
            var answers = context.Answers.Include(t => t.Question).Select(q => new AnswerVM()
            {
                AnswerId = q.AnswerId,
                ProvidedAnswer = q.ProvidedAnswer,
                IsCorrect = q.IsCorrect,
                QuestionId = q.QuestionId,
                QuestionText = q.Question.QuestionText,
                
            }).ToList();

            return answers;
        }
        

        public void Create(CreateAnswerVM answer)
        {
            Answer ans = new Answer
            {
                ProvidedAnswer = answer.ProvidedAnswer,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId,
            };

            context.Answers.Add(ans);
            context.SaveChanges(); 
        }
    }
}
