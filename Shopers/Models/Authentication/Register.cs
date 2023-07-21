using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Shopers.Models.Authentication
{
    public class Register
    {
        [Required(ErrorMessage = "Vui lòng nhập tên"), DisplayName("Tên")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ"), DisplayName("Họ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập"), DisplayName("Tên đăng nhập")]
        public string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Độ dài tối thiểu 6 và phải chứa 1 Chữ hoa, 1 chữ thường, 1 ký tự đặc biệt và 1 chữ số")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string Role { get; set; }

    }
}
