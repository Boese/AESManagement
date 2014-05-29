using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AESManagement.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        public async Task<ActionResult> Index()
        {
            IList<AESDataService.Store> model = new List<AESDataService.Store>();
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                model = await client.getAllStoresAsync();
            }

            return View(model);
        }

        //
        // GET: /Store/Create
        public ActionResult Create()
        {
            Models.StoreModel model = new Models.StoreModel();
            return View(model);
        }

        //
        // POST: /Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                AESDataService.Store store = new AESDataService.Store();
                using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
                {
                    store.name = Request.Form["name"];
                    store.street = Request.Form["street"];
                    store.city = Request.Form["city"];
                    store.state = Request.Form["state"];
                    store.zip = Request.Form["zip"];
                    client.updateStore(store);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Store/Edit/5
        public ActionResult Edit(int id)
        {
            AESManagement.Models.StoreModel model = new Models.StoreModel();
            AESDataService.Store store = new AESDataService.Store();
            using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
            {
                store = client.getStoreInfo(id);
                model.StoreId = store.storeId;
                model.Name = store.name;
                model.Street = store.street;
                model.City = store.city;
                model.State = store.state;
                model.Zip = store.zip;
            }
            return View(model);
        }

        //
        // POST: /Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AESDataService.Store store = new AESDataService.Store();
                using (AESDataService.DataServiceClient client = new AESDataService.DataServiceClient())
                {
                    store.storeId = id;
                    store.name = Request.Form["name"];
                    store.street = Request.Form["street"];
                    store.city = Request.Form["city"];
                    store.state = Request.Form["state"];
                    store.zip = Request.Form["zip"];
                    client.updateStore(store);
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
