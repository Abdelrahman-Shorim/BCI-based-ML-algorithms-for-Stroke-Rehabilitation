using Microsoft.AspNetCore.Identity;

namespace BCI_Project.Models
{
    public class Role : IdentityRole    
    {
        public ICollection<RoleAttributes> RoleAttributesRoles { get; set; }

    }
}
