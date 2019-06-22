using System.IO;
using System.Web;
using System.Web.Mvc;
using SCB.Models.ViewModels;

namespace SCB.Controllers
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