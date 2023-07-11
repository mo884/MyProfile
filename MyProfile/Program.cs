using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProfile.BL.Interface;
using MyProfile.BL.Reposoratory;
using MyProfile.DAL.Database;
using MyProfile.DAL.Entites;
using MyProfile.Mapper;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Enhancement ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Error/Error");
    });


builder.Services.AddIdentityCore<Admin>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<Admin>>(TokenOptions.DefaultProvider);

builder.Services.AddSession(opt =>
opt.IdleTimeout = TimeSpan.FromMinutes(100)
);


// Password and user name configuration

builder.Services.AddIdentity<Admin, IdentityRole>(options =>
{
    // Default Password settings.
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<ApplicationDbContext>();

//Auto Mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

//AddScope 
builder.Services.AddScoped(typeof(IEducationRep), typeof(EducationRep));
builder.Services.AddScoped(typeof(ISkillsRep), typeof(SkillesRep));
builder.Services.AddScoped(typeof(IProjectRep), typeof(ProjectRep));
builder.Services.AddScoped(typeof(IProfileRep), typeof(ProfileRep));
builder.Services.AddScoped(typeof(ICVRep), typeof(CVRep));


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MYProfile}/{action=MyProfile}/{id?}");

app.Run();
