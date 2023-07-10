using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Interface
{
    public interface IEducationRep
    {
        Task<IEnumerable<Education>> GetAll(Expression<Func<Education, bool>> filter = null);
        Task Edit(Education education);
        Task Delete(int id);
        Task Create(Education education);
    }
}
