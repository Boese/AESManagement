using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AESManagement.Controllers
{
    public class PendingController : Controller
    {
        //
        // GET: /Pending/
        public ActionResult UpdatePending()
        {
            AESManagement.AESDataService.Applicant model;
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                model = client.getApplicationsWithStatus("new").First();
            }
            return View("~/Views/Pending/Pending.cshtml", model);
        }
	}
}