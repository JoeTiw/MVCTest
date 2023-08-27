using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VastikaProject;
using VastikaProject.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VastikaProjectContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("VastikaProjectContext") ?? throw new InvalidOperationException("Connection string 'VastikaProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

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
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.Run();