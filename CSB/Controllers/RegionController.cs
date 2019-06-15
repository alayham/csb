using CSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSB.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Code()
        {
            string id;
            if (RouteData.Values.ContainsKey("id"))
            {
                id = RouteData.Values["id"].ToString();
            } else
            {
                return RedirectToAction("Index", "Region");
            }
            int index = Data.getRegionIndex(id);
            if (index > 0)
            {
                RegionViewModel model = new RegionViewModel(index);
                return View(model);
            } else
            {
                return RedirectToAction("Index", "Region");
            }
        }

    }
}