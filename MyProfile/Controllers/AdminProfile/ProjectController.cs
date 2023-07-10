using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProfile.BL.Helper;
using MyProfile.BL.Interface;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Entites;

namespace MyProfile.Controllers.AdminProfile
{
    public class ProjectController : Controller
    {
        private readonly IProjectRep project;
        private readonly IMapper mapper;
        public ProjectController(IProjectRep project, IMapper mapper)
        {
            this.project = project;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await project.GetAll();
                var result = mapper.Map<IEnumerable<ProjectVM>>(data);
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
                var data = await project.GetByID(id);
                var result = mapper.Map<ProjectVM>(data);
                return PartialView("Edit", result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectVM projectVM)
        {
            try
            {
                if (projectVM.PathImage != null)
                projectVM.Image = FileUploader.UploadFile("Img", projectVM.PathImage);
                var result = mapper.Map<Projects>(projectVM);
                await project.Edit(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return PartialView("Edit", projectVM);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await project.GetByID(id);
                var result = mapper.Map<ProjectVM>(data);
                return PartialView("Delete", result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProjectVM projectVM)
        {
            try
            {
                var result = mapper.Map<Projects>(projectVM);
                await project.Delete(result.ID);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", projectVM);
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
        public async Task<IActionResult> Create(ProjectVM projectVM)
        {
            try
            {
                projectVM.Image = FileUploader.UploadFile("Img", projectVM.PathImage);
                var result = mapper.Map<Projects>(projectVM);
                await project.Create(result);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return PartialView("Delete", projectVM);
            }
        }
    }
}
