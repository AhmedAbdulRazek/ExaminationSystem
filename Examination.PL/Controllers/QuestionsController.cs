using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examination.PL.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepo questionRepo;
        private readonly IQuestionTypeRepo questionTypeRepo;
        private readonly IExamRepo examRepo;
        public QuestionsController(IQuestionRepo questionRepo, IExamRepo examRepo, IQuestionTypeRepo questionTypeRepo)
        {
            this.questionRepo = questionRepo;
            this.examRepo = examRepo;
            this.questionTypeRepo = questionTypeRepo;
        }

        public IActionResult Index()
        {
            try
            {
                var questions = questionRepo.GetAll();
                return View(questions);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ExamsList = new SelectList(examRepo.GetAll(), "Id", "Subject");
            ViewBag.QuestionTypesList = new SelectList(questionTypeRepo.GetAll(), "Id", "Type");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateQuestionVM question)
        {

            try
            {
                ViewBag.ExamsList = new SelectList(examRepo.GetAll(), "Id", "Subject");
                ViewBag.QuestionTypesList = new SelectList(questionTypeRepo.GetAll(), "Id", "Type");

                if (ModelState.IsValid)
                {
                    questionRepo.Create(question);
                    return RedirectToAction("Index");
                }
                return View(question);
            }
            catch (Exception)
            {
                return View(question);
            }
        }

    }
}
