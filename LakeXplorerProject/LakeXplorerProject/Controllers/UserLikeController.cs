using LakeXplorerProject.Data.Services;
using LakeXplorerProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LakeXplorerProject.Controllers
{
    public class UserLikeController : Controller
    {
        private readonly LikeService _likeService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserLikeController(LikeService likeService, UserManager<ApplicationUser> userManager)
        {
            _likeService = likeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var userLikes = _likeService.GetUserLikes(user.Id);
            return View(userLikes);
        }
    }
}
