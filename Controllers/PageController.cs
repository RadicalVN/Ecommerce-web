using Microsoft.AspNetCore.Mvc;

namespace OrganicWeb.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PageCanNotFound()
        {
            return View();
        }
    }
}
