using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ApiYtb.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
