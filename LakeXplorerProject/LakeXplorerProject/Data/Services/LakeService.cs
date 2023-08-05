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
                ImageData = data.ImageData,

            };
            await _context.Lakes.AddAsync(newLake);
            await _context.SaveChangesAsync();
        }



        public async Task<Lake> GetLakeByIdAsync(int id)
        {
            var LakeDetails = _context.Lakes
              
               .FirstOrDefaultAsync(n => n.Id == id);

            return await LakeDetails;
        }

        public async Task UpdateLakeAsync(Lake data)
        {
            var dbLake = await _context.Lakes.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbLake != null)
            {
                dbLake.Name = data.Name;
                dbLake.Image = data.Image;
                dbLake.Description = data.Description;
                dbLake.ImageFile = data.ImageFile;

                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var result = await _context.Lakes.FirstOrDefaultAsync(n => n.Id == id);
            _context.Lakes.Remove(result);
            await _context.SaveChangesAsync();
        }





    }
}
