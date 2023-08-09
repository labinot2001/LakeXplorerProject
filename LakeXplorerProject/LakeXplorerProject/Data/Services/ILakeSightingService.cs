using LakeXplorerProject.Data.Base;
using LakeXplorerProject.Data.ViewModels;
using LakeXplorerProject.Models;

namespace LakeXplorerProject.Data.Services
{
    public interface ILakeSightingService : IEntityBaseRepository<LakeSighting>
    {

        Task<LakeSighting> GetLakeSightingByIdAsync(int id);
        Task AddNewLakeSightingAsync(LakeSighting data, string id);
        Task UpdateLakeSightingAsync(LakeSighting data);
        Task DeleteAsync(int id);
        Task<List<LakeSighting>> GetLakeSightingsByUserId(string userId);
        Task<NewLakeDropdownsVM> GetNewLakeDropdownsValues();
        List<LakeSighting> GetLakeSightingsByLakeId(int lakeId);
        Task<int> GetUpdatedLikeCountAsync(int lakeSightingId);
    }
}
