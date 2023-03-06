
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public partial class Course : BaseEntity {
        public Course()
        {
            UserCourses = new Collection<UserCourse>();
        }
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}

