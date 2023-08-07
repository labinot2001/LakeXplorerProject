using LakeXplorerProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LakeXplorerProject.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Lake> Lakes { get; set; }
        public DbSet<LakeSighting> LakeSightings { get; set; }
        public DbSet<Like> Likes { get; set; }



    }
}
