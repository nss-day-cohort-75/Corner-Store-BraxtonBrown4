using System;
using Microsoft.EntityFrameworkCore;
using CornerStore.Models;
public class CornerStoreDbContext : DbContext
{
    public DbSet<Cashier> Cashiers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public CornerStoreDbContext(DbContextOptions<CornerStoreDbContext> context) : base(context)
    {
    }

    // Allows us to configure the schema when migrating as well as seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cashier>().HasData(new Cashier[]
        {
            new Cashier { Id = 1, FirstName = "Alice", LastName = "Smith" },
            new Cashier { Id = 2, FirstName = "Bob", LastName = "Johnson" },
            new Cashier { Id = 3, FirstName = "Charlie", LastName = "Williams" },
            new Cashier { Id = 4, FirstName = "David", LastName = "Brown" },
            new Cashier { Id = 5, FirstName = "Eve", LastName = "Davis" }
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { Id = 1, CategoryName = "Electronics" },
            new Category { Id = 2, CategoryName = "Clothing" },
            new Category { Id = 3, CategoryName = "Home Goods" }
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product { Id = 1, CategoryId = 1, ProductName = "Laptop", Price = 1200.00M, Brand = "Generic" },
            new Product { Id = 2, CategoryId = 1, ProductName = "Smartphone", Price = 800.00M, Brand = "Generic" },
            new Product { Id = 3, CategoryId = 2, ProductName = "T-Shirt", Price = 25.00M, Brand = "Generic" },
            new Product { Id = 4, CategoryId = 2, ProductName = "Jeans", Price = 75.00M, Brand = "Generic" },
            new Product { Id = 5, CategoryId = 3, ProductName = "Coffee Maker", Price = 60.00M, Brand = "Generic" },
            new Product { Id = 6, CategoryId = 3, ProductName = "Blender", Price = 45.00M, Brand = "Generic" },
            new Product { Id = 7, CategoryId = 1, ProductName = "Tablet", Price = 300.00M, Brand = "Generic" },
            new Product { Id = 8, CategoryId = 2, ProductName = "Jacket", Price = 120.00M, Brand = "Generic" },
            new Product { Id = 9, CategoryId = 3, ProductName = "Toaster", Price = 30.00M, Brand = "Generic" },
            new Product { Id = 10, CategoryId = 1, ProductName = "Headphones", Price = 150.00M, Brand = "Generic" }
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order { Id = 1, CashierId = 1, PaidOnDate = DateTime.Now },
            new Order { Id = 2, CashierId = 2, PaidOnDate = DateTime.Now },
            new Order { Id = 3, CashierId = 3, PaidOnDate = DateTime.Now },
            new Order { Id = 4, CashierId = 4, PaidOnDate = DateTime.Now },
            new Order { Id = 5, CashierId = 5, PaidOnDate = DateTime.Now },
            new Order { Id = 6, CashierId = 1, PaidOnDate = DateTime.Now },
            new Order { Id = 7, CashierId = 2, PaidOnDate = DateTime.Now },
            new Order { Id = 8, CashierId = 3, PaidOnDate = DateTime.Now },
            new Order { Id = 9, CashierId = 4, PaidOnDate = DateTime.Now },
            new Order { Id = 10, CashierId = 5, PaidOnDate = DateTime.Now },
            new Order { Id = 11, CashierId = 1, PaidOnDate = DateTime.Now },
            new Order { Id = 12, CashierId = 2, PaidOnDate = DateTime.Now }
        });

        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
            new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderProduct { Id = 2, OrderId = 1, ProductId = 2, Quantity = 2 },
            new OrderProduct { Id = 3, OrderId = 2, ProductId = 3, Quantity = 3 },
            new OrderProduct { Id = 4, OrderId = 2, ProductId = 4, Quantity = 4 },
            new OrderProduct { Id = 5, OrderId = 3, ProductId = 5, Quantity = 5 },
            new OrderProduct { Id = 6, OrderId = 3, ProductId = 6, Quantity = 6 },
            new OrderProduct { Id = 7, OrderId = 4, ProductId = 7, Quantity = 7 },
            new OrderProduct { Id = 8, OrderId = 4, ProductId = 8, Quantity = 8 },
            new OrderProduct { Id = 9, OrderId = 5, ProductId = 9, Quantity = 9 },
            new OrderProduct { Id = 10, OrderId = 5, ProductId = 10, Quantity = 10 },
            new OrderProduct { Id = 11, OrderId = 6, ProductId = 1, Quantity = 1 },
            new OrderProduct { Id = 12, OrderId = 6, ProductId = 3, Quantity = 2 },
            new OrderProduct { Id = 13, OrderId = 7, ProductId = 5, Quantity = 3 },
            new OrderProduct { Id = 14, OrderId = 7, ProductId = 7, Quantity = 4 },
            new OrderProduct { Id = 15, OrderId = 8, ProductId = 9, Quantity = 5 },
            new OrderProduct { Id = 16, OrderId = 8, ProductId = 2, Quantity = 6 },
            new OrderProduct { Id = 17, OrderId = 9, ProductId = 4, Quantity = 7 },
            new OrderProduct { Id = 18, OrderId = 9, ProductId = 6, Quantity = 8 },
            new OrderProduct { Id = 19, OrderId = 10, ProductId = 8, Quantity = 9 },
            new OrderProduct { Id = 20, OrderId = 10, ProductId = 10, Quantity = 10 },
            new OrderProduct { Id = 21, OrderId = 11, ProductId = 2, Quantity = 1 },
            new OrderProduct { Id = 22, OrderId = 11, ProductId = 4, Quantity = 2 },
            new OrderProduct { Id = 23, OrderId = 12, ProductId = 6, Quantity = 3 },
            new OrderProduct { Id = 24, OrderId = 12, ProductId = 8, Quantity = 4 }
        });
    }
}