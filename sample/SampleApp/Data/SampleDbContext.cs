using System;
using Microsoft.EntityFrameworkCore;
using SampleApp.Data.Models;

namespace SampleApp.Data;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }
    public DbSet<SampleGroup> SampleGroups { get; set; }
    public DbSet<SampleTable> SampleTables { get; set; }
}
