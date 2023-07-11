using MyProfile.BL.ModelVM;

namespace MyProfile.BL.Interface
{
    public interface ICVRep
    {
        Task<ProfileCVVM> GetAll();
    }
}
