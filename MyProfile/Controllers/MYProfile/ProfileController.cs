using Microsoft.AspNetCore.Mvc;

namespace MyProfile.Controllers.MYProfile
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
