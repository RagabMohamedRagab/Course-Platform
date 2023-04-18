using Course.Domain.Domains;
using Course.Repository.Context;
using Course.Repository.IRepositories;
using Course.Repository.Repositories;
using Course.Service.IServices;
using Course.Service.Services;
using Course.Service.Utilities;
using Course.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<CourseDbContext>(options =>
                                          options.UseSqlServer(connection));
builder.Services.AddIdentity<AppUser, IdentityRole>()
                          .AddEntityFrameworkStores<CourseDbContext>()
                          .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
});
builder.Services.AddMvc(option =>
{
    var policy = new AuthorizationPolicyBuilder()
                       .RequireAuthenticatedUser()
                       .Build();
    option.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters().AddNToastNotifyToastr(new ToastrOptions()
 {
     ProgressBar = true,
     PositionClass = ToastPositions.TopRight,
     PreventDuplicates = true,
     CloseButton = true,
     ShowDuration = 10
 });
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailSender,EmailSender>();
builder.Services.AddScoped<IFileService, FileService>();
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
      pattern: "{Controller=Account}/{action=login}/{id?}"
    );
app.Run();




