using Microsoft.AspNetCore.Mvc;

namespace MyProfile.Controllers.AdminProfile
{
    public class ProjectController : Controller
    {
        public IActionResult GetALL()
        {
            return View();
        }
    }
}
