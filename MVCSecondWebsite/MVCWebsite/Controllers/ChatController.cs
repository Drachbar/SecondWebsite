using Microsoft.AspNetCore.Mvc;

namespace MVCWebsite.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
