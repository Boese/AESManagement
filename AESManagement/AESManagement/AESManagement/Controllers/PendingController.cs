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
        public async Task<ActionResult> UpdatePending()
        {
            AESManagement.AESDataService.Applicant[] model;
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                model = await client.getApplicationsWithStatusAsync("new");
            }
            return View(model);
        }
	}
}