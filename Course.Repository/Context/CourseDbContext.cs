using Course.Repository.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;
using System.Security.Policy;

namespace Course.Repository.Context {
    public class CourseDbContext : IdentityDbContext {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  To Enable Two Factory Authentcation Enter Phone or Set Manually.
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigurationUserAndRole();
        }
        public virtual DbSet<Course.Domain.Domains.Course> Courses { get; set; }
        public virtual DbSet<Course.Domain.Domains.Title> Titles { get; set; }
        public virtual DbSet<Course.Domain.Domains.Book> Books { get; set; }
        public virtual DbSet<Course.Domain.Domains.Cart> Carts { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }

    }
}




