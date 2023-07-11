using AutoMapper;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Entites;
using System;

namespace MyProfile.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {

            CreateMap<Skills, SkillsVM>();
            CreateMap<SkillsVM, Skills>();


            CreateMap<Education, EducationVM>();
            CreateMap<EducationVM, Education>();


            CreateMap<Projects, ProjectVM>();
            CreateMap<ProjectVM, Projects>();


            CreateMap<ProfileEngineer, ProfileVM>();
            CreateMap<ProfileVM, ProfileEngineer>();
        }
    }
}
