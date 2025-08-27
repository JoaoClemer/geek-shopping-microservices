using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData( new Product
            {
                Id = 1,
                Name = "Camiseta",
                Price = new decimal(79.9),
                Description = "Camiseta do Capitão América",
                CategoryName = "Roupas",
                ImageUrl = ""
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Caneca",
                Price = new decimal(29.9),
                Description = "Caneca do Homem de Ferro",
                CategoryName = "Acessórios",
                ImageUrl = ""
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Boneco",
                Price = new decimal(99.9),
                Description = "Boneco do Hulk",
                CategoryName = "Brinquedos",
                ImageUrl = ""
            });

        }
    }
}
