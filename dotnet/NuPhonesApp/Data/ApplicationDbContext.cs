using System;
using NuPhonesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace NuPhonesApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
       : base(options)
    {
    }

    public DbSet<User> Users {get; set;}
}
