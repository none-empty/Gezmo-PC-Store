using System.Text.Json;
using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Services;
 
using Microsoft.EntityFrameworkCore;
 

 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSingleton<NextUserID>();
builder.Services.AddSingleton<NextOrderID>();
builder.Services.AddSingleton<NextOrderDetailID>();
builder.Services.AddScoped<IOrdersHandler, OrdersHandler>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IGlobalsHelper,GlobalsHelper>();
builder.Services.AddScoped<IDataProvider, DataProvider>();
builder.Services.AddScoped<IUserInfo, UserInfo>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseRouting();
app.UseHttpsRedirection();

app.UseStaticFiles();
 

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();