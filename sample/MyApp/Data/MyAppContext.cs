using System;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data;

public class MyAppContext : DbContext
{
    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 4, Name = "Headset", Price = 40, SerialNumberId = 10 }
        );
        modelBuilder.Entity<SerialNumber>().HasData(
            new SerialNumber { Id = 10, Name = "HSI150", ItemId = 4 }
        );
        modelBuilder.Entity<Category>().HasData(
        new Category { Id = 11, Name = "Electronics" },
        new Category { Id = 22, Name = "Books" }
        );
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Item> Items { get; set; }
    public DbSet<SerialNumber> SerialNumbers { get; set; }
    public DbSet<Category> Categories { get; set; }
}
