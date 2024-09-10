using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    /// <summary>
    /// Represents the database context for accessing news-related data.
    /// </summary>
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for articles in the database.
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for sources in the database.
        /// </summary>
        public DbSet<Source> Sources { get; set; }

        /// <summary>
        /// Configures the relationships and constraints between entities in the model.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Source)
                .WithMany(s => s.Articles)
                .HasForeignKey(a => a.SourceId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
