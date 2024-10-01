using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoListWebMVC.Data;
using TodoListWebMVC.Models;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TodoListWebMVCContext>(options =>
//    options.useMySQL(builder.Configuration.GetConnectionString("TodoListWebMVCContext") ?? throw new InvalidOperationException("Connection string 'TodoListWebMVCContext' not found.")));

builder.Services.AddDbContext<TodoListWebMVCContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("TodoListWebMVCContext"),
                     new MySqlServerVersion(new Version(8, 0, 25))));  // Specify MySQL version

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

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
