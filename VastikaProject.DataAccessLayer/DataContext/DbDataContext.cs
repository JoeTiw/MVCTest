
using Microsoft.EntityFrameworkCore;
using VastikaProject.Entities;

namespace VastikaProject.DataAccessLayer.DataContext;

public class DbDataContext : DbContext
{
    public DbDataContext(DbContextOptions<DbDataContext> options) : base(options){ }
    
    public DbSet<Login> Login { get; set; }

    public DbSet<Customer> Customer { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
    }
}
