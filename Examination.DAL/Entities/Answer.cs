using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Examination.DAL.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string ProvidedAnswer { get; set; }

        public string? StudentId { get; set; }
        public IdentityUser? Student { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        
        public Question Question { get; set; }




    }
}
