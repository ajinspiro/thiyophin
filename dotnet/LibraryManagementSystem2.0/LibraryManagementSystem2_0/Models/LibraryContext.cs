using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem2_0.Models;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Member> Members => Set<Member>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Checkout> Checkouts => Set<Checkout>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.FullName).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(200);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(300).IsRequired();
            entity.Property(e => e.Isbn).HasMaxLength(50);
        });

        modelBuilder.Entity<Checkout>(entity =>
        {
            entity.HasOne(c => c.Member)
                .WithMany(m => m.Checkouts)
                .HasForeignKey(c => c.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(c => c.Book)
                .WithMany(b => b.Checkouts)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(c => new { c.MemberId, c.BookId, c.CheckedOutAt });
        });
    }
}

