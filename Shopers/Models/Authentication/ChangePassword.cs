using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Shopers.Models.Authentication
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu hiện tại"), DisplayName("Mật khẩu hiện tại")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới"), DisplayName("Mật khẩu mới")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập vào ô xác nhận"), DisplayName("Xác nhận mật khẩu")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận khác với mật khẩu mới")]
        public string PasswordConfirm { get; set; }

    }
}
