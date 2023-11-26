using Microsoft.EntityFrameworkCore;
using MMMBuilds.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository,   CategoryRepository>();
builder.Services.AddScoped<IMechRepository, MechRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MMMBuildsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:MMMBuildsDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
DbSeeder.Seed(app);
app.Run();
