using Microsoft.EntityFrameworkCore;
using MyProfile.BL.Interface;
using MyProfile.DAL.Database;
using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Reposoratory
{
    public class ProjectRep : IProjectRep
    {
        private readonly ApplicationDbContext Db;
        public ProjectRep(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public async Task Create(Projects projects)
        {

            await Db.Projects.AddAsync(projects);
            await Db.SaveChangesAsync();

           
        }

        public async Task Delete(int id)
        {
            var result = Db.Projects.Find(id);
            Db.Projects.Remove(result);
        }

        public async Task Edit(Projects projects)
        {
            Db.Projects.Entry(projects).State = EntityState.Modified;
            await Db.SaveChangesAsync();

        }

        public async Task<IEnumerable<Projects>> GetAll(Expression<Func<Projects, bool>> filter = null)
        {
            if (filter != null)
                return
                    await Db.Projects.Where(filter).ToListAsync();
            else
                return
                     await Db.Projects.ToListAsync();
        }
    }
}
