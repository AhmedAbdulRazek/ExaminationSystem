using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //ViewBag.ExamsList = new SelectList(examRepo.GetAll(), "Id", "Subject");
            //return View();
            try
            {
                ViewBag.ExamsList = new SelectList(examRepo.GetAll(), "Id", "Subject");
                var questions = questionRepo.GetAll();
                return View(questions);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Index(QuestionVM question)
        {


            ViewBag.ExamsList = new SelectList(examRepo.GetAll(), "Id", "Subject");

            int id = question.ExamId;

            var questions = questionRepo.GetQuestionsByExamID(id);
            return View(questions);
        }

    }
}