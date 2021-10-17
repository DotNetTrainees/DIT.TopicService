using TopicService.Data.Entities;

namespace TopicService.Infrastructure.Repositories
{
    public interface IReplyRepository : IRepositoryBase<Reply>
    {

    }

    public class ReplyRepository : RepositoryBase<Reply>, IReplyRepository
    {
        public ReplyRepository(DatabaseContext context) : base(context) { }
    }
}
