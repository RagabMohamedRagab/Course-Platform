using Course.Domain.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Course.Repository.Utilities {
    public  static class AddRoleToAdmin {
       public static void ConfigurationUserAndRole(this ModelBuilder modelBuilder)
        {
            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                 new IdentityRole()
                 {
                   
                     Name = "User",
                     NormalizedName = "User".ToUpper()
                 }
                );
            var hasher = new PasswordHasher<IdentityUser>();
            // Seeding the User to AspNetUsers table
            modelBuilder.Entity<AppUser>().HasData(
               new AppUser()
               {
                   Id= "8e445865-a24d-4543-a6c6-9443d048cdb9",
                   UserName = "Admin123@gmail.com",
                   Email = "Admin123@gmail.com",
                   NormalizedUserName = "Admin123@gmail.com".ToUpper(),
                   NormalizedEmail = "Admin123@gmail.com".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin123"),
                   EmailConfirmed = true,
                   LockoutEnabled = true,
                   PhoneNumberConfirmed = true,
                   SecurityStamp = Guid.NewGuid().ToString()
               }
                );
            //Seeding the relation between our user and role to AspNetUserRoles table

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId= "2c5e174e-3b0e-446f-86af-483d56fd7210", // 2c5e174e-3b0e-446f-86af-483d56fd7210
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9" // 8e445865-a24d-4543-a6c6-9443d048cdb9
                }
                );



        }
    }
}



