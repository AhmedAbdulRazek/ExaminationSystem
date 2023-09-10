using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static Examination.DAL.Enums.Enums;

namespace Examination.BL.ViewModels
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public int QuestionTypeId { get; set; }
        public string? QuestionTypeName { get; set; }

        public int Mark { get; set; }
        public int ExamId { get; set; }
        
        public ICollection<AnswerVM>? Answers { get; set; } = new HashSet<AnswerVM>();
    }
}
