using Microsoft.EntityFrameworkCore;
using MiniJobBoard.Web.Data;
using MiniJobBoard.Web.Services;
using MiniJobBoard.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//  Create shared database options
var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase("MiniJobBoardDB")
    .Options;

//  Register as singleton so all controllers share one instance
builder.Services.AddSingleton(new AppDbContext(dbOptions));

builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

//  Middleware setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
