using IdentityCore.Data;
using IdentityCore.Helper;
using IdentityCore.Models;
using IdentityCore.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

// Add Identity

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ProjectContext>();

//Interface registerations

builder.Services.AddScoped<IOathRepo, OathRepo>();


//configiring Password 

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;

});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = builder.Configuration["application:path"];
});

// user claim factory extendid version

builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, ClaimsFactory >();
builder.Services.AddScoped<IGenralPurpose, GenralPurpose >();
builder.Services.AddScoped<IEmailService, EmailService >();


//for Reading congiration from class

builder.Services.Configure<SmtpConfigModel>(builder.Configuration.GetSection("EmailSettings"));
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
