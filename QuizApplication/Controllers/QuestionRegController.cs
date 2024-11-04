using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class QuestionRegController : Controller
    {
        QuestionDB dbobj = new QuestionDB();
     
        public IActionResult questionreg_load()
        {
            TempData["UserType"] = "admin";
            return View();
        }
        public IActionResult questionreg_click(Questions qobj)
        {
            string maxregid = dbobj.Fn_GetQuestionId();
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
            string msg = dbobj.Fn_QuestionsReg(qobj,regId);
            
            return RedirectToAction("ListQuestion_Load", "ListQuestions");
        }
    }
}
