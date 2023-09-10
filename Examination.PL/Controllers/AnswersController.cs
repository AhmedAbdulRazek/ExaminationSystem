using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examination.PL.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IAnswerRepo answerRepo;
        private readonly IQuestionRepo questionRepo;
        private readonly IExamRepo examRepo;
        public AnswersController(IAnswerRepo answerRepo,  IQuestionRepo questionRepo)
        {
            this.questionRepo = questionRepo;
            this.answerRepo = answerRepo;
        }

        public IActionResult Index()
        {
            try
            {
                var answers = answerRepo.GetAll();
                return View(answers);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.QuestionList = new SelectList(questionRepo.GetAll(), "QuestionId", "QuestionText");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAnswerVM answer)
        {

            try
            {
                ViewBag.QuestionList = new SelectList(questionRepo.GetAll(), "QuestionId", "QuestionText");

                if (ModelState.IsValid)
                {
                    answerRepo.Create(answer);
                    return RedirectToAction("Index");
                }
                return View(answer);
            }
            catch (Exception)
            {
                return View(answer);
            }
        }
    }
}
