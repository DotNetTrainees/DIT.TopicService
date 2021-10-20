using System;
using System.Threading.Tasks;
using TopicService.Data;
using TopicService.Data.Entities;
using TopicService.Infrastructure.Models.RequestFeatures;
using TopicService.Infrastructure.Models.RequestFeatures.Reply;

namespace TopicService.Infrastructure.Repositories
{
    public interface IReplyRepository : IRepositoryBase<Reply>
    {
        Task<PagedList<Reply>> GetAllReplyAsync(ReplyParameters parameters);
        Task<Reply> GetReplyByIdAsync(Guid id);
    }

    public class ReplyRepository : RepositoryBase<Reply>, IReplyRepository
    {
        public ReplyRepository(DatabaseContext context) : base(context) { }

        public Task<PagedList<Reply>> GetAllReplyAsync(ReplyParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Reply> GetReplyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public static class ReplyRepositoryExtensions
    {

    }
}
