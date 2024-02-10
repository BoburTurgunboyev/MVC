using FirstMvcProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstMvcProject.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAudit> ProductAudits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Product
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Iphone", Quantiy = 10, Price = 300.99 },
                new Product { Id = 2, Title = "Samsung", Quantiy = 10, Price = 200.99 },
                new Product { Id = 3, Title = "Nokia", Quantiy = 10, Price = 20.99 }

            );

    



        }

    }
}
