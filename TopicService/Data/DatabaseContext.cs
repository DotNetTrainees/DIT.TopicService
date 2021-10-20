using Microsoft.EntityFrameworkCore;
using TopicService.Data.Entities;
using TopicService.Data.Configurations;

namespace TopicService.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new ReplyConfiguration());
        }
    }
}
