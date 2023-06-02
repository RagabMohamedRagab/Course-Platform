﻿
namespace Course.Domain.Domains {
    public class UserCourse {
        public int Id { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Nullable<int> CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public AppUser User { get; set; }
    }
}
