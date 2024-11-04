using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class AdminHomeController : Controller
    {
        //QuestionDB dbobj = new QuestionDB();
        StudentAdminDB dbobj = new StudentAdminDB();
        public IActionResult Admin_load()
        {

            return View();
        }
        public IActionResult Admin_Click()
        {
            return View();
        }
        public IActionResult Student_Score()
        {
            List<Score> getlist = dbobj.Fn_ListStudentScore();
            return View(getlist);
        }
        public IActionResult Admin_Feedback()
        {
            List<Feedback> getlist = dbobj.Fn_ListFeedback();
            return View(getlist);
           
        }
        [HttpPost]
        public IActionResult Admin_Replay(int feedbackId)
        {
            TempData["feedbackId"] = feedbackId;
            return View();
        }
        public IActionResult Admin_ReplayClick(Feedback fed)
        {
            dbobj.Fn_Replay(Convert.ToInt32(TempData["feedbackId"]), fed);
            return View("Admin_load");

        }


    }
}
