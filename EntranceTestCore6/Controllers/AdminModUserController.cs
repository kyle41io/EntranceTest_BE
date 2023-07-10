using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntranceTestCore6.Data;
using EntranceTestCore6.Models;

namespace EntranceTestCore6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminModUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminModUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] AdminModUserModel user)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            appUser.Id = user.Id;
            appUser.isAdmin = user.isAdmin;
            appUser.isActive = user.isActive;

            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}