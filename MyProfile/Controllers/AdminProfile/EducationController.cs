using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProfile.BL.Interface;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Entites;

namespace MyProfile.Controllers.AdminProfile
{
    public class EducationController : Controller
    {
        private readonly IEducationRep education;
        private readonly IMapper mapper;
        public EducationController(IEducationRep education, IMapper mapper)
        {
            this.education = education;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            try
            {
                var data = await education.GetAll();
                var result = mapper.Map<IEnumerable<EducationVM> >(data);
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
                var data = await education.GetByID(id);
                var result = mapper.Map<EducationVM>(data);
                return PartialView("Edit",result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EducationVM educationVM)
        {
            try
            {

                var result = mapper.Map<Education>(educationVM);
                await education.Edit(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return PartialView("Edit", educationVM);
            }
          
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await education.GetByID(id);
                var result = mapper.Map<EducationVM>(data);
                return PartialView("Delete",result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EducationVM educationVM)
        {
            try
            {
                var result = mapper.Map<Education>(educationVM);
                await education.Delete(result.ID);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", educationVM);
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
        public async Task<IActionResult> Create(EducationVM educationVM)
        {
            try
            {
                var result = mapper.Map<Education>(educationVM);
                await education.Create(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", educationVM);
            }
        }
    }
}
