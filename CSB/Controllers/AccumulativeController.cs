using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSB.Models.ViewModels;

namespace CSB.Controllers
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