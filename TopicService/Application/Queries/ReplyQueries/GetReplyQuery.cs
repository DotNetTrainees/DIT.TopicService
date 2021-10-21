using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Infrastructure.Models.DataTransferObjects.Outgoing.Reply;
using TopicService.Infrastructure;

namespace TopicService.Application.Queries.ReplyQueries
{
    public class GetReplyQuery : IRequest<ReplyDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetReplyQueryHandler : IRequestHandler<GetReplyQuery, ReplyDTO>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetReplyQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReplyDTO> Handle(GetReplyQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Replies.GetReplyByIdAsync(request.Id, false);
            return _mapper.Map<ReplyDTO>(result);
        }
    }
}
