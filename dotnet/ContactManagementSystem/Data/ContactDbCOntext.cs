using System;
using ContactManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagementSystem.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options){ }
    public DbSet<ContactGroup> ContactGroups { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
