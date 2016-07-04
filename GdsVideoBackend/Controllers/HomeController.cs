using System.Web.Mvc;
using GdsVideoBackend.Domain;

namespace GdsVideoBackend.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}