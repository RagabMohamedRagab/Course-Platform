using Microsoft.EntityFrameworkCore;
namespace Course.Repository.Context {
    public class CourseDbContext : IdentityDbContext {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }
      
        public virtual DbSet<Course.Domain.Domains.Course> Courses { get; set; }  
        public virtual DbSet<Course.Domain.Domains.UserCourse> UserCourses { get; set; }  
        public virtual DbSet<Course.Domain.Domains.Video> Videos { get; set; }  
        public virtual DbSet<Course.Domain.Domains.Book> Books { get; set; }  
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
        }


    }
}
