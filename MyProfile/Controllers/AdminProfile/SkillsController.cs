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

    public class SkillsController : Controller
    {
        private readonly ISkillsRep skills;
        private readonly IMapper mapper;
        public SkillsController(ISkillsRep skills, IMapper mapper)
        {
            this.skills = skills;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await skills.GetAll();
                var result = mapper.Map<IEnumerable<SkillsVM>>(data);
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
                var data = await skills.GetByID(id);
                var result = mapper.Map<SkillsVM>(data);
                return PartialView("Edit", result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SkillsVM skillsVM)
        {
            try
            {
                var result = mapper.Map<Skills>(skillsVM);
                await skills.Edit(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return PartialView("Edit", skillsVM);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await skills.GetByID(id);
                var result = mapper.Map<SkillsVM>(data);
                return PartialView("Delete", result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SkillsVM skillsVM)
        {
            try
            {
                var result = mapper.Map<Skills>(skillsVM);
                await skills.Remove(result.ID);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", skillsVM);
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
        public async Task<IActionResult> Create(SkillsVM skillsVM)
        {
            try
            {
               
                var result = mapper.Map<Skills>(skillsVM);
                await skills.Create(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", skillsVM);
            }
        }
    }
}
