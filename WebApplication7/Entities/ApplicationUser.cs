using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;

namespace WebApplication7.Entities
{


    public class ApplicationUser : IdentityUser
    {
      //public byte[]? Avatar { get; set; }
      public byte[]? AvatarImage { get; internal set; }


    }
}
