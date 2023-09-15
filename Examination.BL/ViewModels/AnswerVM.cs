using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.ViewModels
{
    public class AnswerVM
    {
        public int AnswerId { get; set; }

        public string ProvidedAnswer { get; set; }

       
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int? SelectedAnswerId { get; set; }
        public List<int>? SelectedAnswerIds { get; set; }


    }
}
