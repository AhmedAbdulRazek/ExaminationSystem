using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.ViewModels
{
    public class QuestionWithAnswersVM
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public int QuestionTypeId { get; set; }
        public string? QuestionTypeName { get; set; }

        public int Mark { get; set; }
        public int ExamId { get; set; }

        public ICollection<AnswerVM> Answers { get; set; } = new HashSet<AnswerVM>();
    }
}
