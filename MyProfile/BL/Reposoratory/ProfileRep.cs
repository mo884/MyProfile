using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyProfile.BL.Interface;
using MyProfile.BL.ModelVM;
using MyProfile.DAL.Database;
using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Reposoratory
{
    public class ProfileRep:IProfileRep
    {
        private readonly ApplicationDbContext Db;
        public ProfileRep(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public async Task Create(ProfileEngineer profile)
        {

            await Db.profile.AddAsync(profile);
            await Db.SaveChangesAsync();


        }

        public async Task Delete(int id)
        {
            var result = Db.profile.Find(id);
            Db.profile.Remove(result);
            await Db.SaveChangesAsync();
        }

    
      

        public async Task<IEnumerable<ProfileEngineer>> GetAll(Expression<Func<ProfileEngineer, bool>> filter = null)
        {
            if (filter != null)
                return
                    await Db.profile.Where(filter).ToListAsync();
            else
                return
                     await Db.profile.ToListAsync();
        }

    

        public async Task<ProfileEngineer> GetByID(int id)
        {
            return await Db.profile.Where(a => a.ID == id).FirstOrDefaultAsync();
        }

        public async Task Update(ProfileEngineer profile)
        {
            var data = Db.profile.Find(profile.ID);
            if (profile.Image == null)
            {

                data.Image = data.Image;
            }
            data.FullName = profile.FullName;
            data.Birthday = profile.Birthday;
            data.Freelance = profile.Freelance;
            data.Adress = profile.Adress;
            data.PhoneNummber = profile.PhoneNummber;
            data.FaceBook = profile.FaceBook;
            data.LinkedIn = profile.LinkedIn;
            data.GitHub = profile.GitHub;
            await Db.SaveChangesAsync();
        }
    }
}
