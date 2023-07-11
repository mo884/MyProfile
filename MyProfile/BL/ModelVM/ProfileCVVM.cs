namespace MyProfile.BL.ModelVM
{
    public class ProfileCVVM
    {
        public IEnumerable<SkillsVM> Skills { get; set; }
        public IEnumerable<EducationVM> Educations { get; set; }

        public IEnumerable<ProjectVM> Projects { get; set; }
        public ProfileVM Profile { get; set; }
       


    }
}
