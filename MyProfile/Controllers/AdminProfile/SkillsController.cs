using Microsoft.AspNetCore.Mvc;

namespace MyProfile.Controllers.AdminProfile
{
    public class SkillsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
