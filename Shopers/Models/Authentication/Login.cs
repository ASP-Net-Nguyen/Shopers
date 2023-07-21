using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopers.Models.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập"), DisplayName("Tên đăng nhập")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu"), DisplayName("mật khẩu")]
        public string Password { get; set; }
    }
}
