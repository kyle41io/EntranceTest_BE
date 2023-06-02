using EntranceTestCore6.Models;
using Microsoft.AspNetCore.Identity;

namespace EntranceTestCore6.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
       
    }
}
