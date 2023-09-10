using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.Entities
{
    public class Result
    {

        public int Id { get; set; }

        public int Score { get; set; }
        
        public int StudentId { get; set; }
        
        public IdentityUser Student { get; set; }

        public int ExamId { get; set; }

        public Exam Exam { get; set; }

    }
}
