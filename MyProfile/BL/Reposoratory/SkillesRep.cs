using Microsoft.EntityFrameworkCore;
using MyProfile.BL.Interface;
using MyProfile.DAL.Database;
using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Reposoratory
{
    public class SkillesRep : ISkillsRep
    {

        private readonly ApplicationDbContext Db;
        public SkillesRep(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public async Task<Skills> Create(Skills skills)
        {

            await Db.Skills.AddAsync(skills);
            await Db.SaveChangesAsync();

            var result = await Db.Skills.OrderByDescending(x => x.ID).FirstOrDefaultAsync();
            return result;
        }

        public async Task Remove(int id)
        {
            var result =await Db.Skills.Where(a=> a.ID ==id).FirstOrDefaultAsync();
            Db.Skills.Remove(result);
            await Db.SaveChangesAsync();
        }

        public async Task Edit(Skills skills)
        {
            Db.Skills.Entry(skills).State = EntityState.Modified;
            await Db.SaveChangesAsync();

        }

        public async Task<IEnumerable<Skills>> GetAll(Expression<Func<Skills, bool>> filter = null)
        {
            if (filter != null)
                return
                    await Db.Skills.Where(filter).ToListAsync();
            else
                return
                     await Db.Skills.ToListAsync();
        }

        public async Task<Skills> GetByID(int id)
        {
            return await Db.Skills.Where(a => a.ID == id).FirstOrDefaultAsync();
        }
    }
}
