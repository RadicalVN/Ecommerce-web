using Microsoft.AspNetCore.Mvc;

namespace OrganicWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SingleProduct()
        {
            return View();
        }
    }
}