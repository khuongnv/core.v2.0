using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Core.Models.Input
{
    public class LoginModel : IValidatableObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
        public long LoginOptionID { get; set; }
        public bool IsRemoteLogOn { get; set; }
        public string RedirectUrl { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(UserName))
                yield return new ValidationResult("Tên đăng nhập không được để trống.");
            if (string.IsNullOrEmpty(Password))
                yield return new ValidationResult("Mật khẩu không được để trống.");
        }

    }
}