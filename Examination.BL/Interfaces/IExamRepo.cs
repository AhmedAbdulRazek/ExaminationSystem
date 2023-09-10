using Examination.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.Interfaces
{
    public interface IExamRepo
    {

        IEnumerable<ExamVM> GetAll();
        ExamVM GetById(int id);
        void Create(CreateExamVM exam);

        void Edit(ExamVM exam);
        
        void Delete(int id);

    }
}
