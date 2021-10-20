using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Application.Models.DataTransferObjects.Outgoing.Reply;
using TopicService.Infrastructure;

namespace TopicService.Application.Queries.ReplyQueries
{
    public class GetReplyQuery : IRequest<ReplyDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetReplyQueryQuery : IRequestHandler<GetReplyQuery, ReplyDTO>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetReplyQueryQuery(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReplyDTO> Handle(GetReplyQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Replies.GetAsync(request.Id, cancellationToken);
            return _mapper.Map<ReplyDTO>(result);
        }
    }
}
