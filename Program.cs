using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Service;
using StudentPortal.Service.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICourseService, CourseServiceImpl>();

// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
//     builder.Configuration.GetConnectionString("StudentPortal"),
//     new MySqlServerVersion(new Version(8,0,44))
// ));

var connectionString = builder.Configuration.GetConnectionString("StudentPortal");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
