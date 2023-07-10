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
            await Db.SaveChangesAsync();
        }

        public async Task Edit(Projects projects)
        {
            var data = Db.Projects.Find(projects.ID);
            if (projects.Image == null)
            {

                data.Image = data.Image;
            }
            data.Name = projects.Name;
            data.Description = projects.Description;
            data.Href= projects.Href;
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
        public async Task<Projects> GetByID(int id)
        {
            return await Db.Projects.Where(a => a.ID == id).FirstOrDefaultAsync();
        }
    }
}
