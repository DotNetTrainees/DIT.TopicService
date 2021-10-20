using System;
using System.Threading.Tasks;
using TopicService.Data;
using TopicService.Data.Entities;
using TopicService.Infrastructure.Models.RequestFeatures;
using TopicService.Infrastructure.Models.RequestFeatures.Topic;

namespace TopicService.Infrastructure.Repositories
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        Task<PagedList<Topic>> GetAllTopicAsync(TopicParameters parameters);
        Task<Topic> GetTopicByIdAsync(Guid id);
    }

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(DatabaseContext context) : base(context) { }

        public Task<PagedList<Topic>> GetAllTopicAsync(TopicParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetTopicByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public static class TopicRepositoryExtensions
    {

    }
}
