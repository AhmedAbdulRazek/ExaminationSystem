using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.ViewModels
{
    public class ExamWithQuestionsVM
    {
        public int Id { get; set; }


        public string Subject { get; set; }

        public List<QuestionWithAnswersVM> Questions { get; set; } = new List<QuestionWithAnswersVM>();
    }
}
