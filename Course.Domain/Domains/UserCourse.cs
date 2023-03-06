
namespace Course.Domain.Domains {
    public partial class UserCourse : BaseEntity {

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public virtual AppUser User { get; set; }
        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}








