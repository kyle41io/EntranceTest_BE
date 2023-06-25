using EntranceTestCore6.Data;
using EntranceTestCore6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EntranceTestCore6.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if(!result.Succeeded) 
            {
                 return string.Empty;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
               issuer: configuration["JWT:ValidIssuer"],
               audience: configuration["JWT:ValidAudience"],
               expires: DateTime.Now.AddMinutes(60),
               claims: authClaims,
               signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
           );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> AddUserAsync(UserModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                Avatar = model.Avatar,
                isAdmin = model.isAdmin,
                isActive = model.isActive,
            };
            return await userManager.CreateAsync(user, model.Password);
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var userModels = new List<UserModel>();
            foreach (var user in users)
            {
                userModels.Add(new UserModel
                {
                    
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    TestAmount = user.TestAmount,
                    Avatar = user.Avatar,
                    isAdmin = user.isAdmin,
                    isActive = user.isActive,
                });
            }
            return userModels;
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserModel
            {
                
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                TestAmount = user.TestAmount,
                Avatar = user.Avatar,
                isAdmin = user.isAdmin,
                isActive = user.isActive,
            };
        }

        public async Task<IdentityResult> UpdateUserAsync(string id, UserModel model)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.DateOfBirth = model.DateOfBirth;
            user.TestAmount = model.TestAmount;
            user.Avatar = model.Avatar;
            user.isAdmin = model.isAdmin;
            user.isActive = model.isActive;
            return await userManager.UpdateAsync(user);
        }
        
    }
}
