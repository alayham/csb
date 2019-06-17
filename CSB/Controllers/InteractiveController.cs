using System.IO;
using System.Web;
using System.Web.Mvc;
using CSB.Models.ViewModels;

namespace CSB.Controllers
{
    public class InteractiveController : Controller
    {
        // GET: Interactive
        public ActionResult Index()
        {
            return View(new MapViewModel());
        }
    }
}