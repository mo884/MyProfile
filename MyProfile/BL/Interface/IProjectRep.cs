using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Interface
{
    public interface IProjectRep
    {
        Task<IEnumerable<Projects>> GetAll(Expression<Func<Projects, bool>> filter = null);
        Task<Projects> Edit(Projects projects);
        Task Delete(Projects projects);
        Task<Projects> Create(Projects projects);
    }
}
