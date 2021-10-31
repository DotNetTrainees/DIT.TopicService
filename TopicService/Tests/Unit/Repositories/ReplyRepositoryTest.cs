using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicService.Data.Entities;
using TopicService.Infrastructure.Repositories;
using Xunit;

namespace TopicService.Tests.Unit.Repositories
{
    public class ReplyRepositoryTest
    {
        private readonly List<Reply> repliesInMemoryDatabase = new List<Reply>
        {
            new Reply
                {
                    Id = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed301"),
                    TopicId = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed300"),
                    UserId = Guid.NewGuid(),
                    Text = "test_text1",
                    Date = DateTime.Now
                },
            new Reply
                {
                    Id = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed302"),
                    TopicId = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed300"),
                    UserId = Guid.NewGuid(),
                    Text = "test_text2",
                    Date = DateTime.Now
                },
            new Reply
                {
                    Id = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed303"),
                    TopicId = new Guid("cd26ccf6-75d6-4521-884f-1693c62ed300"),
                    UserId = Guid.NewGuid(),
                    Text = "test_text3",
                    Date = DateTime.Now
                }
        };

        [Theory]
        [InlineData("cd26ccf6-75d6-4521-884f-1693c62ed301")]
        public async Task GetReplyByIdAsync(Guid id)
        {
            var mockRep = new Mock<IReplyRepository>();
            mockRep.Setup(p => p.GetReplyByIdAsync(id, false).Result)
                .Returns(repliesInMemoryDatabase.FirstOrDefault(p => p.Id == id));

            var reply = await mockRep.Object.GetReplyByIdAsync(id, false);

            Assert.NotNull(reply);
            Assert.Equal(id, reply.Id);
        }
    }
}
