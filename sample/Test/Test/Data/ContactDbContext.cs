using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Test.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> x) : base(x) { }

    

}
