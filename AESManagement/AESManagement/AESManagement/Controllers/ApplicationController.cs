using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AESManagement.AESDataService;

namespace AESManagement.Controllers
{
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/
        public ActionResult Application(int id = 1)
        {
            AESManagement.AESDataService.ApplicantApp model = new AESManagement.AESDataService.ApplicantApp();
            using (DataServiceClient client = new DataServiceClient())
                model = client.getApplication(id);
            return View(model);
        }
	}
}