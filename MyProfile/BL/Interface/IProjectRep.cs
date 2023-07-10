using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Interface
{
    public interface IProjectRep
    {
        Task<IEnumerable<Projects>> GetAll(Expression<Func<Projects, bool>> filter = null);
        Task Edit(Projects projects);
        Task Delete(int id);
        Task Create(Projects projects);
        Task<Projects> GetByID(int id);
    }
}
