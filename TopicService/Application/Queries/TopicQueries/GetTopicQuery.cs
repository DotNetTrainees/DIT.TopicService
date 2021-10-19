using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Application.Models.DataTransferObjects.Outgoing.Topic;
using TopicService.Infrastructure;

namespace TopicService.Application.Queries.TopicQueries
{
    public class GetTopicQuery : IRequest<TopicDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetTopicQueryHandler : IRequestHandler<GetTopicQuery, TopicDTO>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetTopicQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TopicDTO> Handle(GetTopicQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Topics.GetAsync(request.Id, cancellationToken);
            return _mapper.Map<TopicDTO>(result);
        }
    }
}
