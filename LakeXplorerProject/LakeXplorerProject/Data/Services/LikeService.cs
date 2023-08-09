using LakeXplorerProject.Data.Base;
using LakeXplorerProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LakeXplorerProject.Data.Services
{
    public class LikeService : EntityBaseRepository<Like>, ILikeService
    {

        private readonly AppDbContext _context;
        public LikeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task LikeLakeSightingAsync(string userId, int lakeSightingId)
        {
            var like = new Like
            {
                UserId = userId,
                LakeSightingId = lakeSightingId
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
        }

        public async Task UnlikeLakeSightingAsync(string userId, int likeId)
        {
            var like = await _context.Likes
                .Where(l => l.Id == likeId && l.UserId == userId)
                .FirstOrDefaultAsync();

            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }
    }
}
