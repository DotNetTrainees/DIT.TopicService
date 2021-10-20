using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TopicService.Data.Entities;

namespace TopicService.Infrastructure.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasData(
                new Topic 
                { 
                    Id = Guid.NewGuid(), 
                    UserId = Guid.NewGuid(), 
                    Title = "test_title", 
                    Text = "test_text", 
                    Date = DateTime.Now
                });
        }
    }
}
