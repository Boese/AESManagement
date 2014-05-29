using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AESManagement.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /Question/
        public async Task<ActionResult> Index()
        {
            IList<AESDataService.Question> model = new List<AESDataService.Question>();
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                model = await client.getAllQuestionsAsync();
            }

            return View(model);
        }

        //
        // GET: /Question/Create
        public ActionResult Create()
        {
            Models.QuestionModel model = new Models.QuestionModel();
            return View(model);
        }

        //
        // POST: /Question/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                AESDataService.Question question = new AESDataService.Question();
                using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
                {
                    question.theQuestion = Request.Form["theQuestion"];
                    question.theAnswer = Request.Form["theAnswer"];
                    client.updateQuestion(question);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Question/Edit/5
        public ActionResult Edit(int id)
        {
            Models.QuestionModel model = new Models.QuestionModel();
            AESDataService.Question question = new AESDataService.Question();
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                question = client.getQuestion(id);
                model.QuestionId = question.questionId;
                model.Question = question.theQuestion;
                model.Answer = question.theAnswer;
            }
            return View(model);
        }

        //
        // POST: /Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AESDataService.Question question = new AESDataService.Question();
                using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
                {
                    question.questionId = id;
                    question.theQuestion = Request.Form["question"];
                    question.theAnswer = Request.Form["answer"];
                    client.updateQuestion(question);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
