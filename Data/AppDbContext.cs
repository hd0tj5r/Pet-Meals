using Microsoft.EntityFrameworkCore;
using PetmealSystem.Models;

namespace PetmealSystem.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; } = null!;
    public DbSet<Breed> Breeds { get; set; } = null!;

}