using Microsoft.EntityFrameworkCore;


namespace FurFiestaApp.Models
{

public class PetDbContext : DbContext
{
    public PetDbContext(DbContextOptions<PetDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; } = default!;
    public DbSet<Post> Posts { get; set; } 
}
}