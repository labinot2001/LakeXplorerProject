using LakeXplorerProject.Data.Base;
using LakeXplorerProject.Data.ViewModels;
using LakeXplorerProject.Models;

namespace LakeXplorerProject.Data.Services
{
    public interface ILakeSightingService : IEntityBaseRepository<LakeSighting>
    {

        Task<LakeSighting> GetLakeSightingByIdAsync(int id);
        Task AddNewLakeSightingAsync(LakeSighting data);
        Task UpdateLakeSightingAsync(LakeSighting data);
        Task DeleteAsync(int id);

        Task<NewLakeDropdownsVM> GetNewLakeDropdownsValues();
        List<LakeSighting> GetLakeSightingsByLakeId(int lakeId);

    }
}
