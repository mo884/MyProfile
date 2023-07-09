using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Interface
{
    public interface IEducationRep
    {
        Task<IEnumerable<Education>> GetAll(Expression<Func<Education, bool>> filter = null);
        Task<Education> Edit(Education education);
        Task Delete(Education education);
        Task<Education> Create(Education education);
    }
}
