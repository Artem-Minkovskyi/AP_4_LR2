using Microsoft.EntityFrameworkCore;
using AP_4_LR2.Models;

namespace AP_4_LR2
{
    public class LibraryContext : DbContext
    {
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AP_4_LR2.Models.Document> Documents { get; set; } 
        public DbSet<Video> Videos { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }

        private const string DatabasePath = "library.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentItem>()
                .HasDiscriminator<string>("ContentType")
                .HasValue<Book>("Book")
                .HasValue<AP_4_LR2.Models.Document>("Document") 
                .HasValue<Video>("Video")
                .HasValue<Audio>("Audio");

            modelBuilder.Entity<StorageLocation>()
                .HasMany(s => s.Contents)
                .WithOne(c => c.StorageLocation!)
                .HasForeignKey(c => c.StorageLocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}