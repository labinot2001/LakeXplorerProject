using LakeXplorerProject.Data.Base;
using LakeXplorerProject.Data.ViewModels;
using LakeXplorerProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LakeXplorerProject.Data.Services
{
    public class LakeSightingService : EntityBaseRepository<LakeSighting>, ILakeSightingService
    {



        private readonly AppDbContext _context;
        public LakeSightingService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewLakeSightingAsync(LakeSighting data)
        {
            var newLakeSighting = new LakeSighting()
            {
               Longitude = data.Longitude,
               Latitude = data.Latitude,
               Image = data.Image,
               ImageData = data.ImageData,
               LakeId = data.LakeId,

            };
            await _context.LakeSightings.AddAsync(newLakeSighting);
            await _context.SaveChangesAsync();
        }



        public async Task<LakeSighting> GetLakeSightingByIdAsync(int id)
        {
            var LakeSightingDetails = _context.LakeSightings

               .FirstOrDefaultAsync(n => n.Id == id);

            return await LakeSightingDetails;
        }

        public async Task UpdateLakeSightingAsync(LakeSighting data)
        {
            var dbLake = await _context.LakeSightings.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbLake != null)
            {
                dbLake.Longitude = data.Longitude;
                dbLake.Latitude = data.Latitude;
                dbLake.Image = data.Image;
                dbLake.ImageFile = data.ImageFile;
                dbLake.LakeId = data.LakeId;
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var result = await _context.LakeSightings.FirstOrDefaultAsync(n => n.Id == id);
            _context.LakeSightings.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<NewLakeDropdownsVM> GetNewLakeDropdownsValues()
        {
             var response = new NewLakeDropdownsVM()
            {
                 Lakes = await _context.Lakes.OrderBy(n => n.Name).ToListAsync(),
            };

            return response;
        }

        public List<LakeSighting> GetLakeSightingsByLakeId(int lakeId)
        {
            return _context.LakeSightings
                .Where(ls => ls.LakeId == lakeId)
                .ToList();
        }

    }
}
