using Course.dashboard.Areas.UI.Repositories;
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
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<CourseDbContext>(options =>
                                          options.UseLazyLoadingProxies().UseSqlServer(connection));
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
#region Repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITitleRepository, TitleRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ISubscribeRepository,SubscribeRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICourseUIRepository, CourseUIRepository>();
builder.Services.AddScoped<IBookUIRepository, BookUIRepository>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITitleService, TitleService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<ISubscribeService, SubscribeService>();
builder.Services.AddScoped<IEmailSender,EmailSender>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IContactService, ContactService>();
#endregion
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

 app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
      name: "Dashboard",
      pattern: "{Controller=Account}/{action=login}/{id?}"
    );


app.Run();




