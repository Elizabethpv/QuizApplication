using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class StudentHomeController : Controller
    {
        StudentAdminDB dbobj = new StudentAdminDB();
        QuizActionDB dbobjs = new QuizActionDB();
        public IActionResult studenthome_pageload()
        {
            dbobjs.Fn_DeleteSelectoption();
            return View();
        }
        public IActionResult Quiz_start()
        {
            return View();
        }
        public IActionResult student_feedback()
        {
            return View();
        }
        public IActionResult feedback_click(Feedback fobj)
        {
            string msg=dbobj.Fn_Feedback(Convert.ToInt32(TempData["userid"]), fobj);
            TempData["msg"] = msg;
            return View("student_feedback",fobj);
        }
    }
}
