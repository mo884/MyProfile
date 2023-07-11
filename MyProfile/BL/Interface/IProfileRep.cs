using MyProfile.BL.ModelVM;
using MyProfile.DAL.Entites;
using System.Linq.Expressions;

namespace MyProfile.BL.Interface
{
    public interface IProfileRep
    {
        Task Create(ProfileEngineer profile);
        Task Update(ProfileEngineer profile);
        Task Delete(int id);
        Task <IEnumerable<ProfileEngineer>> GetAll(Expression<Func<ProfileEngineer, bool>> filter = null);
        Task<ProfileEngineer> GetByID(int id);

    }
}
