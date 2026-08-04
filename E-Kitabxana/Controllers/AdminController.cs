using Microsoft.AspNetCore.Mvc;

namespace E_Kitabxana.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
