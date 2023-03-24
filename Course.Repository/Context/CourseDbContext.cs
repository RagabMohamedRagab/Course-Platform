using Course.Domain.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;
using System.Security.Policy;

namespace Course.Repository.Context {
    public class CourseDbContext : IdentityDbContext {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }

        public virtual DbSet<Course.Domain.Domains.Course> Courses { get; set; }
        public virtual DbSet<Course.Domain.Domains.UserCourse> UserCourses { get; set; }
        public virtual DbSet<Course.Domain.Domains.Video> Videos { get; set; }
        public virtual DbSet<Course.Domain.Domains.Book> Books { get; set; }
        public virtual DbSet<Course.Domain.Domains.Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  To Enable Two Factory Authentcation Enter Phone or Set Manually.
            base.OnModelCreating(modelBuilder);

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
                );
            var hasher = new PasswordHasher<IdentityUser>();
            // Seeding the User to AspNetUsers table
            modelBuilder.Entity<AppUser>().HasData(
               new AppUser()
               {
                   UserName = "Admin123@gmail.com",
                   Email = "Admin123@gmail.com",
                   NormalizedUserName = "Admin123@gmail.com".ToUpper(),
                   NormalizedEmail = "Admin123@gmail.com".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin123"),
                   EmailConfirmed = true,
                   LockoutEnabled = true,
                   PhoneNumberConfirmed=true,
                   SecurityStamp = Guid.NewGuid().ToString()
               }
         );



        }


    }
}




