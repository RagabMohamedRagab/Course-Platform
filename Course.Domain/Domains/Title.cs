
namespace Course.Domain.Domains {
    public class Title:BaseEntity {
        public Title()
        {
            Courses= new List<Course>();
        }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
