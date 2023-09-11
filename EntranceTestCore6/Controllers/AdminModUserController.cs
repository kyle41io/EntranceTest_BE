using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntranceTestCore6.Data;
using EntranceTestCore6.Models;

namespace EntranceTestCore6.Controllers
{
   // [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminModUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminModUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<AdminModUserModel>> UpdateUser(string email, [FromBody] AdminModUserModel user)
        {
            var appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null)
            {
                return NotFound();
            }
            appUser.Email = user.Email;
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