using Examination.BL.Interfaces;
using Examination.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Examination.PL.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IExamRepo examRepo;

        public ExamsController(IExamRepo examRepo)
        {
            this.examRepo = examRepo;
        }

        public IActionResult Index()
        {
            try
            {
                var exams = examRepo.GetAll();
                return View(exams);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateExamVM exam)
        {

            try
            {
                
                if (ModelState.IsValid)
                {
                    examRepo.Create(exam);
                    return RedirectToAction("Index");
                }
                return View(exam);
            }
            catch (Exception)
            {
                return View(exam);
            }
        }



    }
}
