

using System.ComponentModel.DataAnnotations;

namespace Course.Repository.ViewModeles {
    public class LoginViewModel {
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemmberMe { get; set; }
    }
}

