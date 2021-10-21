using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TopicService.Data;
using TopicService.Data.Entities;
using TopicService.Infrastructure.Models.RequestFeatures;
using TopicService.Infrastructure.Models.RequestFeatures.Reply;

namespace TopicService.Infrastructure.Repositories
{
    public interface IReplyRepository : IRepositoryBase<Reply>
    {
        Task<PagedList<Reply>> GetReplyByTopicIdAsync(Guid topicId, ReplyParameters parameters, bool trackChanges);
        Task<Reply> GetReplyByIdAsync(Guid id, bool trackChanges);
    }

    public class ReplyRepository : RepositoryBase<Reply>, IReplyRepository
    {
        public ReplyRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Reply>> GetReplyByTopicIdAsync(Guid topicId, ReplyParameters parameters, bool trackChanges)
        {
            var result = await GetByCondition(p => p.TopicId == topicId, trackChanges)
                .SearchReply(parameters.SearchTerm)
                .SortReply(parameters.OrderBy)
                .ToListAsync();

            return PagedList<Reply>.ToPagedList(result, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Reply> GetReplyByIdAsync(Guid id, bool trackChanges)
        {
            return await GetByCondition(p => p.Id == id, trackChanges)
                .FirstOrDefaultAsync();
        }
    }

    public static class ReplyRepositoryExtensions
    {
        public static IQueryable<Reply> SearchReply(this IQueryable<Reply> result, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return result;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return result.Where(p => p.Text.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Reply> SortReply(this IQueryable<Reply> result, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return result.OrderBy(e => e.Date);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Reply>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return result.OrderBy(e => e.Date);

            return result.OrderBy(orderQuery);
        }
    }
}
