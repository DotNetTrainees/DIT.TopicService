using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TopicService.Data.Entities;

namespace TopicService.Infrastructure.Configurations
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
        }
    }
}
