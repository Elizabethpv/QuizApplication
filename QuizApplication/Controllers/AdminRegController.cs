using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class AdminRegController : Controller
    {
        RegistrationDB dbobj = new RegistrationDB();
        
        public IActionResult AdminReg_load()
        {  
            return View();
        }
        [HttpPost]
        public IActionResult AdminReg_click(AdminReg adobj)
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
                string msg = dbobj.Fn_AdiminReg(adobj, regId);
                TempData["msg"] = msg;
            }
            return View("AdminReg_load");
            
        }
    }
    
}
