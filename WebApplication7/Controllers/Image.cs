
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class Image : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;

        public IActionResult Index()
        {
            return View();
        }
        public Image(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.AvatarImage != null && user.AvatarImage.Length > 1)
                return File(user.AvatarImage, "image/...");
            else
            {
                var avatarPath = "/Images/anonymous.png";

                return File(_env.WebRootFileProvider.GetFileInfo(avatarPath).CreateReadStream(), "image/...");
            }
        }
    }
    
}
