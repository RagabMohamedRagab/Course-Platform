
using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public partial class Title:BaseEntity {
        public Title()
        {
            Courses= new List<Course>();
        }
        [MaxLength(120)]
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
