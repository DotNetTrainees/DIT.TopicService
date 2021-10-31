using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopicService.Data.Entities;
using TopicService.Infrastructure.Repositories;
using Xunit;

namespace TopicService.Tests.Unit.Repositories
{
    public class TopicRepositoryTest
    {
        private readonly List<Topic> topicsInMemoryDatabase = new List<Topic>
        {
            new Topic
                {
                    Id = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed301"),
                    UserId = Guid.NewGuid(),
                    Title = "test_title1",
                    Text = "test_text1",
                    Date = DateTime.Now
                },
            new Topic
                {
                    Id = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed302"),
                    UserId = Guid.NewGuid(),
                    Title = "test_title2",
                    Text = "test_text2",
                    Date = DateTime.Now
                },
            new Topic
                {
                    Id = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed303"),
                    UserId = Guid.NewGuid(),
                    Title = "test_title3",
                    Text = "test_text3",
                    Date = DateTime.Now
                }
        };

        [Theory]
        [InlineData("cd26ccf6-75d6-4521-884f-1693c62ed301")]
        public async Task GetTopicByIdAsync(Guid id)
        {
            var mockRep = new Mock<ITopicRepository>();
            mockRep.Setup(p => p.GetTopicByIdAsync(id, false).Result)
                .Returns(topicsInMemoryDatabase.FirstOrDefault(p => p.Id == id));

            var topic = await mockRep.Object.GetTopicByIdAsync(id, false);

            Assert.NotNull(topic);
            Assert.Equal(id, topic.Id);
        }
    }
}
