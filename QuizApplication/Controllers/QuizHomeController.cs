using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;


namespace QuizApplication.Controllers
{
    public class QuizHomeController : Controller
    {
        QuizActionDB dbobj = new QuizActionDB();
        public IActionResult Questionactions_Load(int id,Questions qobj)
        {
            string maxquesid = dbobj.Fn_GetQuestioncount();
            int maxques = Convert.ToInt32(maxquesid);
            ViewBag.maxquestion=maxques;
            if (id == maxques)
            {
                return View("checkanswer_beforesubmit");
            }
            if (id == 0)
            {
                id = 1;
                var questions = dbobj.Fn_GetQuestionschoice(id).FirstOrDefault();               
                return View(questions);
            }
            else
            {
                var question = dbobj.Fn_GetQuestionschoice(id).FirstOrDefault();
                return View(question);
            }          
        }

        [HttpGet]
        public IActionResult NextClick(int currentQuestionId, int currentCount,Questions qobj)
        {
                  
            int nextQuestionId = currentQuestionId + 1;
            string maxquesid = dbobj.Fn_GetQuestioncount();
            int maxques = Convert.ToInt32(maxquesid);
            ViewBag.maxquestion = maxques;
            ViewBag.maxcountquestions = currentQuestionId;
            string present = dbobj.Fn_Selectedoptioncount(nextQuestionId);
            if(present=="1")
            {
                string userselectop = dbobj.Fn_AccessDBOption(nextQuestionId);
                qobj.Selected_OP = userselectop;
            }
            
            var nextQuestion = dbobj.Fn_GetQuestionschoice(nextQuestionId).FirstOrDefault();  
            if (nextQuestion == null)
            {             
                return RedirectToAction("Questionactions_Load", new { id = currentQuestionId});
            }
            qobj.Question_Id = nextQuestionId;
            qobj.QuestionText = nextQuestion.QuestionText;
            qobj.Ques_OPA = nextQuestion.Ques_OPA;
            qobj.Ques_OPB = nextQuestion.Ques_OPB;
            qobj.Ques_OPC = nextQuestion.Ques_OPC;
            qobj.Ques_OPD = nextQuestion.Ques_OPD;
            return View("Questionactions_Load", qobj);
            //return RedirectToAction("Questionactions_Load", new { id = nextQuestionId, currentCount});
        }

        [HttpPost]
        public IActionResult SubmitAnswer(int id, string Selected_OP,string actions)
        {
            if (actions == "Next >>")
            {
                if (id == 1)
                {
                    string present = dbobj.Fn_Selectedoptioncount(id);
                    if (present =="0")
                    {
                        dbobj.Fn_Selectoptinsert(id, Selected_OP);
                    }
                    string dBsel_op = dbobj.Fn_GetExistingOption(id);
                    if(present == "1" && dBsel_op!=Selected_OP)
                    {
                        dbobj.Fn_UpdateSelectedoption(id,Selected_OP);
                    }
                    return RedirectToAction("NextClick", new { currentQuestionId = id});
                }
                else
                {
                   
                    string present = dbobj.Fn_Selectedoptioncount(id);
                    if (present == "0")
                    {
                        dbobj.Fn_Selectoptinsert(id, Selected_OP);
                    }
                    string dBsel_op = dbobj.Fn_GetExistingOption(id);
                    if (present == "1" && dBsel_op != Selected_OP)
                    {
                        dbobj.Fn_UpdateSelectedoption(id, Selected_OP);
                    }
                    
                    return RedirectToAction("NextClick", new { currentQuestionId = id });
                }
            }
            else if(actions == "<< Previous")
            { 
                return RedirectToAction("PreviousClick", new { currentQuestionId = id });
            }
            return View("Questionactions_Load");

        }
        public IActionResult PreviousClick(int currentQuestionId,Questions qobj)
        {           
            int questionId = currentQuestionId - 1;
            string maxquesid = dbobj.Fn_GetQuestioncount();
            int maxques = Convert.ToInt32(maxquesid);
            ViewBag.maxquestion = maxques;
            string userselectop = dbobj.Fn_AccessDBOption(questionId);
            qobj.Selected_OP = userselectop;         
            
            if (questionId < 1)
            {
                return RedirectToAction("Questionactions_Load", new { id = 1 });
            }
            var question = dbobj.Fn_GetQuestionschoice(questionId).FirstOrDefault();
            if (question == null)
            {
                return RedirectToAction("Questionactions_Load", new { id = currentQuestionId });
            }
            qobj.Question_Id=questionId;
            qobj.QuestionText = question.QuestionText; 
            qobj.Ques_OPA = question.Ques_OPA; 
            qobj.Ques_OPB = question.Ques_OPB;
            qobj.Ques_OPC = question.Ques_OPC;
            qobj.Ques_OPD = question.Ques_OPD;
            return View("Questionactions_Load", qobj);
        }
        public IActionResult FinalScore()
        {
            return View();
        }
        public IActionResult checkanswer_beforesubmit()
        {
            
            return View();
        }
        public IActionResult checkanswer_click()
        {
            string score=dbobj.Fn_FinalScore();
            TempData["score"] =score;
            ViewBag.TotalScore = score;
            return View("FinalScore");
        }
        public IActionResult FinalScore_click()
        {
            dbobj.Fn_Scoreinsert(Convert.ToInt32(TempData["userid"]), Convert.ToInt32(TempData["score"]));
            dbobj.Fn_DeleteSelectoption();
            return RedirectToAction("studenthome_pageload", "StudentHome");
        }
    }
}

