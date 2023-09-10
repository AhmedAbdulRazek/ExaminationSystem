using Examination.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.Interfaces
{
    public interface IQuestionTypeRepo
    {
        IEnumerable<QuestionTypeVM> GetAll();
    }
}
