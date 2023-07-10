using Microsoft.EntityFrameworkCore;
using MyProfile.BL.Interface;
using MyProfile.DAL.Database;
using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Reposoratory
{
    public class EducationRep : IEducationRep
    {
        private readonly ApplicationDbContext Db;
        public EducationRep(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public async Task Create(Education education)
        {

            await Db.Educations.AddAsync(education);
            await Db.SaveChangesAsync();


        }

        public async Task Delete(int id)
        {
            var result = Db.Educations.Find(id);
            Db.Educations.Remove(result);
            await Db.SaveChangesAsync();
        }

      

        public async Task Edit(Education education)
        {
            Db.Educations.Entry(education).State = EntityState.Modified;
            await Db.SaveChangesAsync();

        }

        public async Task<IEnumerable<Education>> GetAll(Expression<Func<Education, bool>> filter = null)
        {
            if (filter != null)
                return
                    await Db.Educations.Where(filter).ToListAsync();
            else
                return
                     await Db.Educations.ToListAsync();
        }

        public async Task<Education> GetByID(int id)
        {
           return await Db.Educations.Where(a=> a.ID == id).FirstOrDefaultAsync();
        }
    }
}
