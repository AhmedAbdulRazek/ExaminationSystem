using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.ViewModels
{
    public class CreateExamVM
    {
        [Required]
        public string Subject { get; set; }

    }
}
