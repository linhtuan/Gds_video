using System.Web.Mvc;
using GdsVideoBackend.Domain;

namespace GdsVideoBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategorysService _categorysService;

        public HomeController(ICategorysService categorysService)
        {
            _categorysService = categorysService;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var test = _categorysService.GetCategory();
            return View();
        }
	}
}