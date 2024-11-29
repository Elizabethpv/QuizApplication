using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class StudentRegController : Controller
    {
        RegistrationDB dbobj = new RegistrationDB();
        public IActionResult Studreg_Pageload()
        {
            return View();
        }
        public IActionResult Studreg_click(StudentReg sdbobj)
        {
            if (ModelState.IsValid)
            {
                string maxregid = dbobj.Fn_GetRegId();
                int Regid = 0;
                if (maxregid == "")
                {
                    Regid = 1;
                }
                else
                {
                    int newid = Convert.ToInt32(maxregid);
                    Regid = newid + 1;
                }
                int regId = Regid;
                string msg = dbobj.Fn_StudentReg(sdbobj, regId);
                TempData["msg"] = msg;
            }
            return View("Studreg_Pageload");
            
        }
    }
}
