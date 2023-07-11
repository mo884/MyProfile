using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProfile.BL.Helper;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Entites;
using System;
using System.Data;

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
            try
            {

				dynamic result;
				if (model.Email!=null&&model.Passward!=null)
                {
					var userEmail = await userManager.FindByEmailAsync(model.Email.Trim());
					if (userEmail != null)
					{
						result = await signInManager.PasswordSignInAsync(userEmail, model.Passward, true, false);
						if (result.Succeeded)
						{

							return RedirectToAction("GetAll", "Education");


						}
                        else
                        {
							TempData["error"] = "Email Not Register";
							return PartialView("Login", model);
						}




					}
					else
					{
						return PartialView("Login", model);
					}
				}
                else
                {
                    TempData["error"] = "Email Not Register";
                }
				

				




				
			}
            catch (Exception)
            {

                throw;
            }
			// var userName = await userManager.FindByNameAsync(model.UserName);


			return PartialView("Login", model);




		}
        [Authorize]

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
        #region Sign Out

        [HttpGet]
        public async Task<IActionResult> LogOff(string id)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion
    }
}
