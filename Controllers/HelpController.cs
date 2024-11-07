using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Help()
        {
            return View();
        }
    }
}