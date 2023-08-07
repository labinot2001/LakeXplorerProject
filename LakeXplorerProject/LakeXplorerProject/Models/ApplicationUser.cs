using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LakeXplorerProject.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name address is required")]
        public string? FullName { get; set; }

        //email, username, and password (identity)

    }
}
