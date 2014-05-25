using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AESManagement.AESDataService;
using System.Threading.Tasks;
using System.Web.Services;

namespace AESManagement.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/
        public async Task<ActionResult> Applicant(int id = -1)
        {
            AESManagement.AESDataService.ApplicantApp model = new AESManagement.AESDataService.ApplicantApp();
            if (id != -1)
            {
                using (DataServiceClient client = new DataServiceClient())
                {
                    await client.lockAppAsync(id);
                    model = await client.getApplicationAsync(id);
                }
                return View(model);
            }
            else
                return View(model);
        }

        [HttpPost]
        public ActionResult UpdateNotes(AESManagement.Models.NoteModel noteModel)
        {
                using (DataServiceClient client = new DataServiceClient())
                {
                    client.unlockApp(noteModel.appId);
                    client.updateNotes(noteModel.appId, noteModel.note);
                }

                return RedirectToAction("Applicant", "Application", noteModel.appId);
        }

        [HttpPost]
        public ActionResult Approve(int appId = -1)
        {
            using (DataServiceClient client = new DataServiceClient())
            {
                client.unlockApp(appId);
                client.updateStatus(appId, "approved");
            }

            return RedirectToAction("Applicant", "Application",appId);
        }

        [HttpPost]
        public ActionResult Deny(int appId = -1)
        {
            using (DataServiceClient client = new DataServiceClient())
            {
                client.unlockApp(appId);
                client.updateStatus(appId, "denied");
            }

            return RedirectToAction("Applicant", "Application",appId);
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            return RedirectToAction("Applicant", "Application",1);
        }
	}
}