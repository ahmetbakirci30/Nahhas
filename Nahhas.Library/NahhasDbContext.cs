using Microsoft.EntityFrameworkCore;
using Nahhas.Library.Entities;
using Nahhas.Library.Entities.Statuses;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nahhas.Library
{
    public class NahhasDbContext : DbContext
    {
        public NahhasDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < 10; i++)
            {
                var id = Guid.NewGuid();

                modelBuilder.Entity<Category>().HasData(new Category { Id = id, Name = $"{i}th Love", CoverPath = "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", AdditionDate = DateTime.UtcNow, LastModified = DateTime.UtcNow });
                modelBuilder.Entity<Video>().HasData(new Video { Id = Guid.NewGuid(), CategoryId = id, Title = $"{i}th Video", VideoPath = "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", CoverPath = "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", AdditionDate = DateTime.UtcNow, LastModified = DateTime.UtcNow });
                modelBuilder.Entity<Image>().HasData(new Image { Id = Guid.NewGuid(), CategoryId = id, ImagePath = "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", AdditionDate = DateTime.UtcNow, LastModified = DateTime.UtcNow });
                modelBuilder.Entity<Quote>().HasData(new Quote { Id = Guid.NewGuid(), CategoryId = id, Content = $"{i}th Quote.", AdditionDate = DateTime.UtcNow, LastModified = DateTime.UtcNow });
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            var currentDate = DateTime.UtcNow;

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