using Microsoft.AspNetCore.Identity;

namespace MyProfile.DAL.Entites
{
    public class Admin: IdentityUser
    {
        public string Name { get; set; }

    }
}
