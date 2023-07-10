using EntranceTestCore6.Models;
using EntranceTestCore6.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EntranceTestCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountsController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        
        [Authorize]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserModel addUserModel)
        {
            var result = await accountRepo.AddUserAsync(addUserModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var result = await accountRepo.SignInAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await accountRepo.GetAllUsersAsync();
            return Ok(users);
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await accountRepo.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
        [Authorize]
        [HttpPut("UpdateUser/{Id}")]
        public async Task<IActionResult> UpdateUser(string Id, UserModel updateUserModel)
        {
            var result = await accountRepo.UpdateUserAsync(Id, updateUserModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }
    }
}