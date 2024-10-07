using CremeWorks.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CremeWorks.Backend;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Entry> Entries { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<Entry>().HasIndex(e => e.Hash).IsUnique();
        modelBuilder.Entity<Entry>().HasOne(e => e.Creator).WithMany(u => u.Entries).HasForeignKey(e => e.CreatorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Entry>().Property(p => p.Content).HasColumnType("MediumBlob");
    }
}
