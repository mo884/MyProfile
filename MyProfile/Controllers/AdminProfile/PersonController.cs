using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProfile.BL.Helper;
using MyProfile.BL.Interface;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Entites;
using System.Data;

namespace MyProfile.Controllers.AdminProfile
{
    [Authorize]

    public class PersonController : Controller
    {

        private readonly IProfileRep profile;
        private readonly IMapper mapper;
        public PersonController(IProfileRep profile, IMapper mapper)
        {
            this.profile = profile;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await profile.GetAll();
                var result = mapper.Map<IEnumerable<ProfileVM>>(data);
                return View(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {

                var data = await profile.GetByID(id);
                var result = mapper.Map<ProfileVM>(data);
                return PartialView("Edit", result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProfileVM profileVM)
        {
            try
            {
                if (profileVM.PathImage != null)
                    profileVM.Image = FileUploader.UploadFile("Img", profileVM.PathImage);
                var result = mapper.Map<ProfileEngineer>(profileVM);
                await profile.Update(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return PartialView("Edit", profileVM);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await profile.GetByID(id);
                var result = mapper.Map<ProfileVM>(data);
                return PartialView("Delete", result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProfileVM profileVM)
        {
            try
            {
                var result = mapper.Map<ProfileEngineer>(profileVM);
                await profile.Delete(result.ID);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", profileVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {

                return PartialView("Create");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProfileVM profileVM)
        {
            try
            {
                profileVM.Image = FileUploader.UploadFile("Img", profileVM.PathImage);

                var result = mapper.Map<ProfileEngineer>(profileVM);
                await profile.Create(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", profileVM);
            }
        }
    }
}
