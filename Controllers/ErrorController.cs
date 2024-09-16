using Microsoft.AspNetCore.Mvc;

namespace KSR_Docker.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            Response.StatusCode = 500;
            return View("Error");
        }

        public IActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }
    }
}
