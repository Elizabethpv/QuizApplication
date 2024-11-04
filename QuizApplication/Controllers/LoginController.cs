using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class LoginController : Controller
    {
        RegistrationDB dbobj = new RegistrationDB();
        public IActionResult Login_Load()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login_Click(Login lobj)
        {
            string userid = dbobj.Fn_LoginID(lobj);
            ViewBag.userid = userid;
            TempData["userid"]=userid;
            string count = dbobj.Fn_Login(lobj);
            if(count=="1")
            {
                string usertype = dbobj.Fn_LoginType(lobj);
                TempData["UserType"] = usertype;
                if (usertype == "admin")
                {
                    return RedirectToAction("Admin_load", "AdminHome");
                }
                else if (usertype == "student")
                {
                    return RedirectToAction("studenthome_pageload", "StudentHome");
                }
            }
            return View("Login_Load");
        }
    }
}
