using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<BooksModel>()
            .HasMany(b => b.reviews)
            .WithOne(r => r.book)
            .HasForeignKey(r => r.bookID)
            .HasPrincipalKey(b => b.id);
    }

    public DbSet<AuthorsModel> Authors { get; set; } = null!;
    public DbSet<BooksModel> Books { get; set; } = null!;
}