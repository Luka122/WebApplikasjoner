using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View("Help");
        }
    }
}