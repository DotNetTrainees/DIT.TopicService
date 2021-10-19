using TopicService.Infrastructure.Repositories;

namespace TopicService.Infrastructure
{
    public interface IRepositoryManager
    {
        ITopicRepository Topics { get; }
        IReplyRepository Replies { get; }
    }

    public class RepositoryManager : IRepositoryManager
    {
        private readonly DatabaseContext _context;
        private ITopicRepository _topicRepository;
        private IReplyRepository _replyRepository;

        public RepositoryManager(DatabaseContext context)
        {
            _context = context;
        }

        public ITopicRepository Topics
        {
            get
            {
                if (_topicRepository == null)
                    _topicRepository = new TopicRepository(_context);
                return _topicRepository;
            }
        }

        public IReplyRepository Replies
        {
            get
            {
                if (_replyRepository == null)
                    _replyRepository = new ReplyRepository(_context);
                return _replyRepository;
            }
        }

    }
}
