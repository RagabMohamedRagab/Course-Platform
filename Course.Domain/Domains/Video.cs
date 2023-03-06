
namespace Course.Domain.Domains {
    public partial class Video : BaseEntity {
        public byte[] Data { get; set; }

        [ForeignKey(nameof(UserCourse))]
        public int? UserCourseID { get; set; }
        public virtual UserCourse UserCourse { get; set; }
    }
}

