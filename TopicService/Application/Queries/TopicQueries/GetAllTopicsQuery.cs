using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Infrastructure.Models.DataTransferObjects.Outgoing.Topic;
using TopicService.Infrastructure;
using TopicService.Infrastructure.Models.RequestFeatures.Topic;

namespace TopicService.Application.Queries.TopicQueries
{
    public class GetAllTopicsQuery : IRequest<IEnumerable<TopicDTO>>
    {
        public TopicParameters Parameters { get; set; }
    }

    public class GetAllTopicsQueryHandler : IRequestHandler<GetAllTopicsQuery, IEnumerable<TopicDTO>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetAllTopicsQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopicDTO>> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            var topic = await _repository.Topics.GetAllTopicAsync(request.Parameters, false);

            return _mapper.Map<IEnumerable<TopicDTO>>(topic);
        }
    }
}
