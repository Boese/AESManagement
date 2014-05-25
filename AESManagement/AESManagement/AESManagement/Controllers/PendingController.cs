using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AESManagement.Controllers
{
    [Authorize]
    public class PendingController : Controller
    {
        //
        // GET: /Pending/
        public ActionResult UpdatePending()
        {
            if (Session["_Status"] == null)
            {
                Session["_Status"] = "new";
            }
            List<AESManagement.AESDataService.Applicant> model = new List<AESDataService.Applicant>();
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                foreach (var app in client.getApplicationsWithStatus((string)Session["_Status"]))
                {
                    model.Add(app);
                }
            }
            return PartialView("Pending", model);
        }

        public ActionResult setSession(string status = "new")
        {
            if (Session["_Locked"] != null)
            {
                using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
                {
                    client.unlockApp((int)Session["_Locked"]);
                }
            }
            Session["_Status"] = status;

            return RedirectToAction("Applicant","Application",-1);
        }
	}
}