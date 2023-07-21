using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Shopers.Models.Authentication
{
    public class ProfileUser : IdentityUser
    {
        [DisplayName("Tên")]
        public string FirstName { get; set; }
        [DisplayName("Họ")]
        public string LastName { get; set; }
        [DisplayName("Ảnh cá nhân")]
        public string ProfilePicture { get; set; }

    }
}
