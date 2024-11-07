using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;

namespace QuizApplication.Controllers
{
    public class ListQuestionsController : Controller
    {
        QuestionDB dbobj = new QuestionDB();
        public IActionResult ListQuestion_Load()
        {            
            List<Questions> getlist = dbobj.Fn_ListQuestions();
            return View(getlist);         
        }
        public IActionResult EditQuestions_Load(int id)
        {
            TempData["UserType"] = "admin";
            TempData["pid"] = id;
            var getlist = dbobj.Fn_ListQuestionswithID(id);
            return View(getlist);
          
        }
        [HttpPost]
        public IActionResult ListQuestion_Editclick(Questions obj)
        {
            int uid = Convert.ToInt32(TempData["pid"]);
            string msg = dbobj.Fn_UpdateQuestion(uid,obj);
            TempData["msg1"] = "Updated Succussflly";
            return RedirectToAction("ListQuestion_Load", "ListQuestions");
            
        }
        public IActionResult ListQuestion_deleteclick(int id)
        {
            int deleted = dbobj.Fn_DeleteQuestion(id);
            if(deleted==1)
            {
                TempData["msg1"] = "Deleted Succussflly";
            }
            dbobj.Fn_UpdateQuestionID();
            return RedirectToAction("ListQuestion_Load", "ListQuestions");
        }
    }
}
