using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class LogoutController : Controller
    {
        QuizActionDB dbobj = new QuizActionDB();
        public IActionResult Logout_load()
        {
            TempData.Clear();
            dbobj.Fn_DeleteSelectoption();
            return RedirectToAction("Index", "Home");
        }
    }
}
