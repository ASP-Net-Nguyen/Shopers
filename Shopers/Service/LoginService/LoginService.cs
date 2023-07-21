using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using Shopers.Models;
using Shopers.Models.Authentication;
using System.Security.Claims;

namespace Shopers.Service.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<ProfileUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ProfileUser> signInManager;
        public LoginService(UserManager<ProfileUser> userManager,
            SignInManager<ProfileUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<Status> RegisterAsync(Register model)
        {
            var status = new Status();
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Người dùng đã tồn tại";
                return status;
            }
            ProfileUser user = new ProfileUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            //Create a User
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Tạo tài khoản thất bại";
                return status;
            }
            //Create a "user" role if it doesn't already exist
            if (!await roleManager.RoleExistsAsync("user"))
                await roleManager.CreateAsync(new IdentityRole("user"));
            //Assign the "user" role to the user
            await userManager.AddToRoleAsync(user, "user");

            status.StatusCode = 1;
            status.Message = "Bạn đã đăng ký thành công";
            return status;
        }
        public async Task<Status> LoginAsync(Login model)
        {
            var status = new Status();
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return status;
            }
            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }
            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Logged in successfully";
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User is locked out";
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on logging in";
            }
            return status;
        }
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
        public async Task<Status> ChangePasswordAsync(ChangePassword model, string username)
        {
            var status = new Status();
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                status.Message = "User does not exist";
                status.StatusCode = 0;
                return status;
            }
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                status.Message = "Password has updated successfully";
                status.StatusCode = 1;
            }
            else
            {
                status.Message = "Some error occcured";
                status.StatusCode = 0;
            }
            return status;
        }
    }
}
