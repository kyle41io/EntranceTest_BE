/*using EntranceTestCore6.Models;
using EntranceTestCore6.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntranceTestCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public ProductsController(IUserRepository repo)
        {
            _userRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userRepo.GetAllUsersAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepo.GetUserAsync(id);
            return user == null ? NotFound() : Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserModel model)
        {
            try
            {
                var newUserId = await _userRepo.AddUserAsync(model);
                var user = await _userRepo.GetUserAsync(newUserId);
                return user == null ? NotFound() : Ok(user);
            }
            catch
            { 
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id , UserModel model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }
            await _userRepo.UpdateUserAsync(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepo.DeleteUserAsync(id);
            return Ok();
        }
    }
}
*/