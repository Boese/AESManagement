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
        public ActionResult UpdatePending(string status)
        {
            if (status != null)
            {
                Session["_Status"] = status;
            }
            else
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
	}
}