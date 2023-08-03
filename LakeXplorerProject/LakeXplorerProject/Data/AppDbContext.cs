using Microsoft.EntityFrameworkCore;

namespace LakeXplorerProject.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }


    }
}
