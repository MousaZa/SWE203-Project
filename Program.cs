using Microsoft.EntityFrameworkCore;
using UniProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt => {
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true; 
}
);

//db configurations
builder.Services.AddDbContext<LibraryContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<AppIdentityDbContext>(opts => 
    opts.UseSqlite(
        builder.Configuration["ConnectionStrings:IdentityDBConnection"]));


//identity configuration
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();


builder.Services.ConfigureApplicationCookie(opt => {
    opt.AccessDeniedPath = "/Home/AccessDenied"; 
    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout"; 
    opt.Cookie.HttpOnly = true; 
    opt.ExpireTimeSpan = TimeSpan.FromDays(14); 
    opt.SlidingExpiration = true; 
});




var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseAuthentication();
app.UseAuthorization();

IdentitySeedData.EnsurePopulated(app);


app.Run();