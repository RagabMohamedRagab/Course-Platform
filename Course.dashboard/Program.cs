using Course.Domain.Domains;
using Course.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddXmlSerializerFormatters();
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<CourseDbContext>(options =>
                                          options.UseSqlServer(connection));
builder.Services.AddIdentity<AppUser, IdentityRole>()
                          .AddEntityFrameworkStores<CourseDbContext>()
                          .AddDefaultTokenProviders();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
      name: "Dashboard",
      pattern: "{Controller=Home}/{action=index}/{id?}"
    );
app.Run();



