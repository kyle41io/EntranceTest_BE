using EntranceTestCore6.Data;
using EntranceTestCore6.Models;
using Microsoft.AspNetCore.Identity;

namespace EntranceTestCore6.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> AddUserAsync(UserModel model);
        public Task<string> SignInAsync(SignInModel model);
        public Task<List<UserModel>> GetAllUsersAsync();
        public Task<UserModel> GetUserByIdAsync(string Id);
        public Task<IdentityResult> UpdateUserAsync(string Id, UserModel model);

    }
}
