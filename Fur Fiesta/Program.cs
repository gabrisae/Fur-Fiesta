using Microsoft.EntityFrameworkCore;
using FurFiestaApp.Models; 

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PetContext")));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<PetDbContext>();
    // Ensure the database is created
    dbContext.Database.EnsureCreated();
    // Seed the database
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();  // The default HSTS value is 30 days. You may want to change this for production scenarios.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
