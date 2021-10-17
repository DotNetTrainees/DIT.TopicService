using TopicService.Data.Entities;

namespace TopicService.Infrastructure.Repositories
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {

    }

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(DatabaseContext context) : base(context) { }
    }
}
