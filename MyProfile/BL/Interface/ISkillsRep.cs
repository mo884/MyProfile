using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Interface
{
    public interface ISkillsRep
    {
        Task<IEnumerable<Skills>> GetAll(Expression<Func<Skills, bool>> filter = null);
        Task Edit(Skills skills);
        Task Delete(int id);
        Task<Skills>Create(Skills skills);
        Task<Skills> GetByID(int id);

    }
}
