

using System.ComponentModel.DataAnnotations;

namespace Course.Repository.ViewModeles {
    public class RegisterViewModel {
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(100),
        DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Repeat Password"),
        MaxLength(100),
        DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Not Match")]
        public string RepeatPassword { get; set; }
        [Display(Name = "Email Address"),
        MaxLength(100),
        DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Display(Name = "Repeat Email Address"),
        MaxLength(100)]
        [Compare(nameof(EmailAddress), ErrorMessage = "Not Match"),
         DataType(DataType.EmailAddress)]
        public string RepeatEmailAddress { get; set; }

    }
}




