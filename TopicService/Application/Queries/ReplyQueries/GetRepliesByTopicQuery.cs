using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Infrastructure.Models.DataTransferObjects.Outgoing.Reply;
using TopicService.Infrastructure;
using TopicService.Infrastructure.Models.RequestFeatures.Reply;

namespace TopicService.Application.Queries.ReplyQueries
{
    public class GetRepliesByTopicQuery : IRequest<IEnumerable<ReplyDTO>>
    {
        public ReplyParameters Parameters { get; set; }
        public Guid TopicId { get; set; }
    }

    public class GetAllReplyQueryHandler : IRequestHandler<GetRepliesByTopicQuery, IEnumerable<ReplyDTO>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetAllReplyQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReplyDTO>> Handle(GetRepliesByTopicQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Replies.GetReplyByTopicIdAsync(request.TopicId, request.Parameters, false);
            return _mapper.Map<IEnumerable<ReplyDTO>>(result);
        }
    }
}
