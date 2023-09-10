using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static Examination.DAL.Enums.Enums;

namespace Examination.BL.ViewModels
{
    public class CreateQuestionVM
    {

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public int QuestionTypeId { get; set; }

        [Required]
        public int Mark { get; set; }
        public int ExamId { get; set; }
        
    }
}
