using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;

namespace Examination.PL.Controllers
{
    public class HomeController : Controller
    {

        private readonly IExamRepo examRepo;
        private readonly IQuestionRepo questionRepo;

        public HomeController(IExamRepo examRepo, IQuestionRepo questionRepo)
        {
            this.examRepo = examRepo;
            this.questionRepo = questionRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {

            try
            {
                ViewBag.ExamsList = new SelectList(examRepo.GetAll(), "Id", "Subject");
                var questions = questionRepo.GetQuestionsByFirstExamID();
                return View(questions);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        //public ActionResult Index(QuestionVM question)
        public ActionResult Index(int ExamId,[FromForm] List<AnswerVM> answers)
        {


            ViewBag.ExamsList = new SelectList(examRepo.GetAll(), "Id", "Subject");


            var questions = questionRepo.GetQuestionsByFirstExamID();
            if (ExamId > 0)
                questions = questionRepo.GetQuestionsByExamID(ExamId);


            return View(questions);
        }

    }
}