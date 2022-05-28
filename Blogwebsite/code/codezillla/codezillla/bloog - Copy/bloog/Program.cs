using bloog.DataAccess.Data;


using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using blog.DataAccess.Repository.IRepository;
using blog.DataAccess.Repository;

using bulkey.DataAccess.DnInitilizer;
using blog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    //(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(connectionString));//builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IDbInitializer, DbInitializer>();
//builder.Services.AddSingleton<IEmailSender,EmailSender>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IEmailSender, EmailSender>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = $"/Identity/Account/Login";
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRazorPages();

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

SeedDatabase();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}


