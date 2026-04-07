using DAL.system;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext() { }
        /*------------------------------------------------------------------*/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        /*------------------------------------------------------------------*/

        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Seed keys
        //    var user1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        //    var user2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

        //    modelBuilder.Entity<User>().HasData(
        //        new User
        //        {
        //            Id = user1Id,
        //            Name = "Alice",
        //            password = "password",
        //            Address = "123 Main St",
        //            Role = "Customer",
        //        },
        //        new User
        //        {
        //            Id = user2Id,
        //            Name = "Bob",
        //            password = "adminpass",
        //            Role = "Admin",
        //        }
        //    );

        //    modelBuilder.Entity<Category>().HasData(
        //        new Category { Id = 1, Name = "Electronics" },
        //        new Category { Id = 2, Name = "Books" }
        //    );

        //    modelBuilder.Entity<Product>().HasData(
        //        new Product { Id = 1, Name = "Laptop", Desciption = "Gaming Laptop", CategotyId = 1 },
        //        new Product { Id = 2, Name = "C# Programming", Desciption = "Learn C#", CategotyId = 2 }
        //    );

        //    modelBuilder.Entity<Cart>().HasData(
        //        new Cart { Id = 1, UserId = user1Id, Created_at = new DateTime(2023, 1, 1) }
        //    );

        //    modelBuilder.Entity<Order>().HasData(
        //        new Order
        //        {
        //            Id = 1,
        //            UserId = user1Id,
        //            Status = "Pending",
        //            TotalAmount = 1200.00m,
        //            ShippingAddress = "123 Main St",
        //            PlacedAt = new DateTime(2023, 1, 2)
        //        }
        //    );

        //    modelBuilder.Entity<CartItem>().HasData(
        //        new CartItem { Id = 1, CartId = 1, ProductId = 1, Quantity = 1 }
        //    );

        //    modelBuilder.Entity<OrderItem>().HasData(
        //        new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1200.00m }
        //    );

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> orderItems  { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
