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
            IEnumerable<AESManagement.AESDataService.Applicant> model;
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                model = client.getApplicationsWithStatus("new");
            }
            return View(model);
        }
	}
}