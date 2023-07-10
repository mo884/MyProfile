using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProfile.BL.Helper;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Entites;
using System;

namespace MyProfile.Controllers.AdminProfile
{
    public class AccountController : Controller
    {
        #region Prop
        private readonly UserManager<Admin> userManager;
        private readonly SignInManager<Admin> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        #endregion


        #region Ctor
        public AccountController(UserManager<Admin> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Admin> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;

        }
        #endregion
        public IActionResult Login()
        {
            return PartialView("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            // var userName = await userManager.FindByNameAsync(model.UserName);
            var userEmail = await userManager.FindByEmailAsync(model.Email);

            dynamic result;




            if (userEmail != null)
            {
                result = await signInManager.PasswordSignInAsync(userEmail, model.Passward, model.RemberMe, false);
                if (result.Succeeded)
                {

                    return RedirectToAction("GetAll", "Education");


                }




            }


           return PartialView("Login", model);



        }

        #region Registration 
        [HttpGet]
        public IActionResult Registration()
        {
            return PartialView("Registration");
        }

        [HttpPost]
        public async Task<IActionResult> Registration(AdminVM model)
        {
            var user = new Admin()
            {
                UserName = model.UserName,
                Email = model.Email,
                
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                var data = await userManager.FindByEmailAsync(model.Email);
                //Add Patient Role
                var role = await roleManager.FindByNameAsync("Admin");
                //Add Patient
                var result1 = await userManager.AddToRoleAsync(data, role.Name);
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);


        }
        #endregion

    }
}
