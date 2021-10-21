using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TopicService.Data;
using TopicService.Data.Entities;
using TopicService.Infrastructure.Models.RequestFeatures;
using TopicService.Infrastructure.Models.RequestFeatures.Topic;

namespace TopicService.Infrastructure.Repositories
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        Task<PagedList<Topic>> GetAllTopicAsync(TopicParameters parameters, bool trackChanges);
        Task<Topic> GetTopicByIdAsync(Guid id, bool trackChanges);
    }

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Topic>> GetAllTopicAsync(TopicParameters parameters, bool trackChanges)
        {
            var result = await GetAll(trackChanges)
                .SearchTopic(parameters.SearchTerm)
                .SortTopic(parameters.OrderBy)
                .ToListAsync();

            return PagedList<Topic>.ToPagedList(result, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Topic> GetTopicByIdAsync(Guid id, bool trackChanges)
        {
            return await GetByCondition(p => p.Id == id, trackChanges)
                .Include(p => p.Replies)
                .FirstOrDefaultAsync();
        }
    }

    public static class TopicRepositoryExtensions
    {
        public static IQueryable<Topic> SearchTopic(this IQueryable<Topic> result, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return result;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return result.Where(p => p.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Topic> SortTopic(this IQueryable<Topic> result, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return result.OrderBy(e => e.Date);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Topic>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return result.OrderBy(e => e.Date);

            return result.OrderBy(orderQuery);
        }
    }
}
