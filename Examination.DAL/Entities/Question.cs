using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static Examination.DAL.Enums.Enums;

namespace Examination.DAL.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        public string QuestionText { get; set; }


        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public int Mark { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();


    }
}
