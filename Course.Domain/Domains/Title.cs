
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course.Domain.Domains {
    public partial class Title:BaseEntity {
        public Title()
        {
            Courses= new List<Course>();
        }
        [MaxLength(120)]
        public string? Name { get; set; }
        public string? Logo { get; set; }
        [Column(TypeName ="decimal(18,0)")]
        public decimal Price { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public string? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Subscribe> Subscribes { get; set; }
    }
}
