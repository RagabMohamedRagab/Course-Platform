

using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
	public class ContactUs: BaseEntity {
        public int  Id { get; set; }
        [MaxLength(150),DataType(DataType.Text)]
        public string?  Name { get; set; }
		[MaxLength(150), DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
        [DataType(DataType.Text)]
        public string? Message { get;set; }
    }
}
