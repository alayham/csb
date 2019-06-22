using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCB.Models.ViewModels;

namespace SCB.Controllers
{
    public class AccumulativeController : Controller
    {
        // GET: Accomulative
        public ActionResult Index()
        {
            return View(new MapViewModel());
        }
    }
}