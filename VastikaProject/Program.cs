using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VastikaProject;
using VastikaProject.BusinessAccessLayer.Interfaces;
using VastikaProject.BusinessAccessLayer.Services;
using VastikaProject.DataAccessLayer.DataContext;
using VastikaProject.DataAccessLayer.Interfaces;
using VastikaProject.DataAccessLayer.Services;




var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddTransient<ILoginRepo, LoginRepo>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

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