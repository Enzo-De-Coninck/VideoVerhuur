using Microsoft.EntityFrameworkCore;
using VideoData.Models;
using VideoVerhuur.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<VideoVerhuurDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("VideoConnection"),
//    x => x.MigrationsAssembly("VideoData")));
builder.Services.AddTransient<VideoVerhuurDbContext>();
builder.Services.AddTransient<InlogService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
