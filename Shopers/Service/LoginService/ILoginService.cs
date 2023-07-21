using Shopers.Models;
using Shopers.Models.Authentication;

namespace Shopers.Service.LoginService
{
    public interface ILoginService
    {
        Task<Status> LoginAsync(Login model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(Register model);
        Task<Status> ChangePasswordAsync(ChangePassword model, string username);
    }
}
