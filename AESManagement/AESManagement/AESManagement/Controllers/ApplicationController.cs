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

        public ActionResult SearchByName(AESManagement.Models.searchModel searchModel)
        {
            int appId = -1;
            if (searchModel.firstname != null && searchModel.lastname != null)
            {
                using (DataServiceClient client = new DataServiceClient())
                {
                    appId = client.getApplicationsWithName(searchModel.firstname, searchModel.lastname).First();
                }
            }
            return Redirect("Applicant/" + appId.ToString());
        }

        [HttpPost]
        public ActionResult UpdateNotes(AESManagement.Models.NoteModel noteModel)
        {
                using (DataServiceClient client = new DataServiceClient())
                {
                    client.unlockApp(noteModel.appId);
                    client.updateNotes(noteModel.appId, noteModel.note);
                }

                return RedirectToAction("Applicant", "Application", -1);
        }

        [HttpPost]
        public ActionResult Approve(int appId = -1)
        {
            using (DataServiceClient client = new DataServiceClient())
            {
                client.unlockApp(appId);
                client.updateStatus(appId, "approved");
            }

            return RedirectToAction("Applicant", "Application",-1);
        }

        [HttpPost]
        public ActionResult Deny(int appId = -1)
        {
            using (DataServiceClient client = new DataServiceClient())
            {
                client.unlockApp(appId);
                client.updateStatus(appId, "denied");
            }

            return RedirectToAction("Applicant", "Application",-1);
        }

        
	}
}