using Examination.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.BL.Interfaces
{
    public interface IQuestionRepo
    {
        IEnumerable<QuestionVM> GetAll();
        //QuestionVM GetById(int id);
        void Create(CreateQuestionVM question);

        void Edit(QuestionVM question);
        IEnumerable<QuestionVM> GetQuestionsByFirstExamID();
        IEnumerable<QuestionVM> GetQuestionsByExamID(int id);
        void Delete(int id);

    }
}
