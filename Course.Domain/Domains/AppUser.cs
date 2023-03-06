using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public partial class AppUser:IdentityUser{
        public AppUser()
        {
            UserCourses = new Collection<UserCourse>();
        }
        [StringLength(maximumLength: 150)]
        public string About { get; set; }
          public byte[] Logo { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
