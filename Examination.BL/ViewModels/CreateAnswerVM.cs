using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.ViewModels
{
    public class CreateAnswerVM
    {

        
        [Required]
        public string ProvidedAnswer { get; set; }

       
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public int QuestionId { get; set; }


    }
}
