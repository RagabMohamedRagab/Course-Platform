using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public class Gallery: BaseEntity {
        public int Id { get; set; }
        [DataType(DataType.Text), MaxLength(150)]
        public string? Text { get; set; }
        [MaxLength(150), DataType(DataType.ImageUrl)]
        public string? Img { get; set; }
    }
}
