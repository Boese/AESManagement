using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AESManagement.Controllers
{
    [Authorize]
    public class PositionController : Controller
    {
        //
        // GET: /Position/
        public async Task<ActionResult> Index()
        {
            IList<AESDataService.Position> model = new List<AESDataService.Position>();
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                model = await client.getAllPositionsAsync();
            }
            return View(model);
        }

        //
        // GET: /Position/Create
        public ActionResult Create()
        {
            Models.PositionModel model = new Models.PositionModel();
            return View(model);
        }

        //
        // POST: /Position/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                AESDataService.Position position = new AESDataService.Position();
                using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
                {
                    position.title = Request.Form["title"];
                    position.education = Request.Form["education"];
                    position.description = Request.Form["description"];
                    position.requirements = Request.Form["requirements"];
                    position.pay = Request.Form["pay"];
                    await client.updatePositionAsync(position);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Position/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            AESManagement.Models.PositionModel model = new Models.PositionModel();
            AESDataService.Position position = new AESDataService.Position();
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                position = await client.getPositionAsync(id);
                model.Id = position.positionId;
                model.Title = position.title;
                model.Description = position.description;
                model.Education = position.education;
                model.Requirements = position.requirements;
                model.Pay = position.pay;
                await client.updatePositionAsync(position);
            }
            return View(model);
        }

        //
        // POST: /Position/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                AESDataService.Position position = new AESDataService.Position();
                using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
                {
                    position.positionId = id;
                    position.title = Request.Form["title"];
                    position.education = Request.Form["education"];
                    position.description = Request.Form["description"];
                    position.requirements = Request.Form["requirements"];
                    position.pay = Request.Form["pay"];
                    await client.updatePositionAsync(position);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
