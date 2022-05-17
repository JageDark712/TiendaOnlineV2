using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TiendaOnlineV2.Web.Data.Entities;
using TiendaOnlineV2.Web.Models;

namespace TiendaOnlineV2.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}
