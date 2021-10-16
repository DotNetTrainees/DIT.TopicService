using Microsoft.EntityFrameworkCore;
using TopicService.Data.Entities;
using TopicService.Infrastructure.Configurations;

namespace TopicService.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new ReplyConfiguration());
        }
    }
}
