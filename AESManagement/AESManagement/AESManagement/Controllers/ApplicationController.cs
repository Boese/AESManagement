﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AESManagement.AESDataService;
using System.Threading.Tasks;

namespace AESManagement.Controllers
{
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/
        public async Task<ActionResult> Applicant(int id = 1)
        {
            AESManagement.AESDataService.ApplicantApp model = new AESManagement.AESDataService.ApplicantApp();
            using (DataServiceClient client = new DataServiceClient())
                model = await client.getApplicationAsync(id);
            return View(model);
        }
	}
}