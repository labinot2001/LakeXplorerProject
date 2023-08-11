using LakeXplorerProject.Data.Base;
using LakeXplorerProject.Models;

namespace LakeXplorerProject.Data.Services
{
    public interface ILikeService : IEntityBaseRepository<Like>
    {

        Task LikeLakeSightingAsync(string userId, int lakeSightingId);
        Task UnlikeLakeSightingAsync(string userId, int likeId);
        Task<IEnumerable<Like>> GetUserLikes(string userId);
    }
}
