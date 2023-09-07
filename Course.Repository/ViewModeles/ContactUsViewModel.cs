
using System.ComponentModel.DataAnnotations;

namespace Course.Repository.ViewModeles {
	public class ContactUsViewModel {
		[MaxLength(150), DataType(DataType.Text)]
		public string Name { get; set; }
		[MaxLength(150), DataType(DataType.EmailAddress)]
		public string Email { get; set; }
        [DataType(DataType.Text)]
        public string Message { get; set; }
    }
}
