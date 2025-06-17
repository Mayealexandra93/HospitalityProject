using Microsoft.AspNetCore.Mvc;

namespace HospitalityProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
