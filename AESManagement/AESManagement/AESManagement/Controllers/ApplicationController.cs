using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AESManagement.AESDataService;
using System.Threading.Tasks;

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
                    model = await client.getApplicationAsync(id);
                    //await client.lockAppAsync(id);
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
                    client.updateNotes(noteModel.appId, noteModel.note);
                }

                return RedirectToAction("Applicant", "Application", noteModel.appId);
        }

	}
}