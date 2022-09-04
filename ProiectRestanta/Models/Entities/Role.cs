using Microsoft.AspNetCore.Identity;

namespace ProiectRestanta.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
