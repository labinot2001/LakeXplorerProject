using LakeXplorerProject.Data.Base;
using LakeXplorerProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LakeXplorerProject.Data.Services
{
    public class LakeService : EntityBaseRepository<Lake>, ILakeServices
    {
        private readonly AppDbContext _context;
        public LakeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewLakeAsync(Lake data)
        {
            var newLake = new Lake()
            {
                Name = data.Name,
                Image = data.Image,
                Description = data.Description,

            };
            await _context.Lakes.AddAsync(newLake);
            await _context.SaveChangesAsync();
        }



        public Task<Lake> GetCarByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateLakeAsync(Lake data)
        {
            var dbLake = await _context.Lakes.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbLake != null)
            {
                dbLake.Name = data.Name;
                dbLake.Image = data.Image;
                dbLake.Description = data.Description;

                await _context.SaveChangesAsync();
            }
        }


    }
}
