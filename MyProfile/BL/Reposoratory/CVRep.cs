using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProfile.BL.Interface;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Database;

namespace MyProfile.BL.Reposoratory
{
    public class CVRep : ICVRep
    {
        private readonly ApplicationDbContext Db;
        private readonly IMapper mapper;
        public CVRep(ApplicationDbContext Db, IMapper mapper)
        {
            this.Db = Db;
            this.mapper = mapper;
        }
        public async Task<ProfileCVVM> GetAll()
        {
            var skills = await Db.Skills.ToListAsync();
            var skillsVM =mapper.Map<IEnumerable<SkillsVM>>(skills);
            var Projects = await Db.Projects.ToListAsync();
            var projectsVM = mapper.Map<IEnumerable<ProjectVM>>(Projects);
            var Education = await Db.Educations.ToListAsync();
            var EducationVM = mapper.Map<IEnumerable<EducationVM>>(Education);
            var person = await Db.profile.FirstOrDefaultAsync();
            var profile = mapper.Map<ProfileVM>(person);
            ProfileCVVM Profile = new ProfileCVVM() { 
            Skills  = skillsVM,
            Projects = projectsVM,
            Educations = EducationVM,
            Profile = profile
            };
            return Profile;
        }
    }
}
