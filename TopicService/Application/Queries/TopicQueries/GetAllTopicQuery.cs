using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Application.Models.DataTransferObjects.Outgoing.Topic;
using TopicService.Infrastructure;

namespace TopicService.Application.Queries.TopicQueries
{
    public class GetAllTopicQuery : IRequest<IEnumerable<TopicDTO>>
    {

    }

    public class GetAllTopicQueryHandler : IRequestHandler<GetAllTopicQuery, IEnumerable<TopicDTO>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetAllTopicQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopicDTO>> Handle(GetAllTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await _repository.Topics.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TopicDTO>>(topic);
        }
    }
}
