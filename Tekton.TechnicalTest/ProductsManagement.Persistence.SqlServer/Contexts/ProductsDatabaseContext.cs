using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductsManagement.ApplicationCore.Entities;

namespace ProductsManagement.Persistence.SqlServer.Contexts;

public partial class ProductsDatabaseContext : DbContext
{
    public ProductsDatabaseContext()
    {
    }

    public ProductsDatabaseContext(DbContextOptions<ProductsDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("ProductsDBConnectionString");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
