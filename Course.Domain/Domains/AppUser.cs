using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public partial class AppUser:IdentityUser{
        public AppUser()
        {
            UserCourses = new Collection<UserCourse>();
        }
        public string? Name { get; set; }
        [StringLength(maximumLength: 150)]
        public string? About { get; set; }
        public string? Logo { get; set; }
        [Column(TypeName ="nvarchar(150)")]
        public string? Facebook { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Twitter { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Instagram { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Profile { get; set; } 
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
