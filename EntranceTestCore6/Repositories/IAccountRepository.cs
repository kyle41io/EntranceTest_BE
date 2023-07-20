using EntranceTestCore6.Data;
using EntranceTestCore6.Models;
using Microsoft.AspNetCore.Identity;

namespace EntranceTestCore6.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> AddUserAsync(UserModel model);
        public Task<string> SignInAsync(SignInModel model);
        public Task<List<UserModifyModel>> GetAllUsersAsync();
        public Task<UserModifyModel> GetUserByEmailAsync(string email);
        public Task<IdentityResult> UpdateUserAsync(string email, UserModifyModel model);

    }
}
