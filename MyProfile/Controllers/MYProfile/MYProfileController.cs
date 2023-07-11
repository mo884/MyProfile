using Microsoft.AspNetCore.Mvc;
using MyProfile.BL.Helper;
using MyProfile.BL.Interface;
using MyProfile.BL.ModelVM;

namespace MyProfile.Controllers.MYProfile
{
    public class MYProfileController : Controller
    {
        private readonly ICVRep cV;
        public MYProfileController(ICVRep cV)
        {
            this.cV = cV;
        }
        public async Task<IActionResult> MyProfile()
        {
            var data = await cV.GetAll();
            return View(data);
        }
        [HttpPost]

        public IActionResult SendMail(MailVM mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailSender.SendEmail(mail);
                    return RedirectToAction("MyProfile", "MYProfile");
                }

                return RedirectToAction("MyProfile", "MYProfile");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Faild";
                return RedirectToAction("MyProfile", "MYProfile");
            }
        }
    }
}
