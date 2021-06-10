using Microsoft.EntityFrameworkCore;
using Nahhas.Shared.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nahhas.Shared
{
    public class NahhasDbContext : DbContext
    {
        public NahhasDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < 10; i++)
            {
                var id = Guid.NewGuid();

                modelBuilder.Entity<Category>().HasData(new Category { Id = id, Name = $"Aşk{i}" });
                modelBuilder.Entity<Video>().HasData(new Video { Id = Guid.NewGuid(), CategoryId = id, Title = $"Sevgililer{i}", VideoPath = "https://localhost:44308/statuses/videos/a.mp4", CoverPath = "https://localhost:44308/statuses/images/a.png" });
                modelBuilder.Entity<Image>().HasData(new Image { Id = Guid.NewGuid(), CategoryId = id, ImagePath = "https://localhost:44308/statuses/images/a.png" });
                modelBuilder.Entity<Quote>().HasData(new Quote { Id = Guid.NewGuid(), CategoryId = id, Content = $"My {i}th Status." });
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            var currentDate = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = currentDate;

                if (entry.State == EntityState.Added)
                    entry.Property("AdditionDate").CurrentValue = currentDate;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}