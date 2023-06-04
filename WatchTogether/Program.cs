using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchTogether.Application.Hubs;
using WatchTogether.Application.Interfaces;
using WatchTogether.Application.Mappings;
using WatchTogether.Application.Services;
using WatchTogether.Data;
using WatchTogether.Domain.Entities;
using WatchTogether.Infrastructure.Repository.Abstract;
using WatchTogether.Infrastructure.Repository.Concrete;
using WatchTogether.Presentation.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(W2GProfile));
builder.Services.AddAutoMapper(typeof(ViewModelProfiler));

builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();
app.UseEndpoints(endpoints => { endpoints.MapHub<RoomHub>("/roomHub"); });
app.Run();
