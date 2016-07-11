using System.Web.Mvc;

namespace GiaoDucSomVideo.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [Route("category/{category?}")]
        public ActionResult Index(string category)
        {
            return View();
        }
    }
}