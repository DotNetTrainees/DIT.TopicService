using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Application.Models.DataTransferObjects.Outgoing.Reply;
using TopicService.Infrastructure;

namespace TopicService.Application.Queries.ReplyQueries
{
    public class GetAllReplyQuery : IRequest<IEnumerable<ReplyDTO>>
    {

    }

    public class GetAllReplyQueryHandler : IRequestHandler<GetAllReplyQuery, IEnumerable<ReplyDTO>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetAllReplyQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReplyDTO>> Handle(GetAllReplyQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Replies.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ReplyDTO>>(result);
        }
    }
}
