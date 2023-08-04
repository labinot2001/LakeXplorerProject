using LakeXplorerProject.Data.Base;
using LakeXplorerProject.Models;

namespace LakeXplorerProject.Data.Services
{
    public interface ILakeServices : IEntityBaseRepository<Lake>
    {
        Task<Lake> GetCarByIdAsync(int id);
        Task AddNewLakeAsync(Lake data);
        Task UpdateLakeAsync(Lake data);
        Task DeleteAsync(int id);

        //Task AddNewLakeAsync(NewLakeVM data);
        //Task UpdateLakeAsync(NewLakeVM data);
        //Task<NewLakeDropdownsVM> GetNewLakeDropdownsValues();

    }
}
