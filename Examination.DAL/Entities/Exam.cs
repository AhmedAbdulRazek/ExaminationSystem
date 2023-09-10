using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Examination.DAL.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();

    }
}
