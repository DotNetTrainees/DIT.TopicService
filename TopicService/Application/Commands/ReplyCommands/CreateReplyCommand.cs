using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Application.Models.DataTransferObjects.Incoming.Reply;
using TopicService.Data.Entities;
using TopicService.Infrastructure;

namespace TopicService.Application.Commands.ReplyCommands
{
    public class CreateReplyCommand : IRequest<Reply>
    {
        public CreateReplyDTO Reply { get; set; }
    }

    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, Reply>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CreateReplyCommandHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Reply> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = _mapper.Map<Reply>(request.Reply);

            reply.Id = Guid.NewGuid();
            reply.Date = DateTime.Now;

            return await _repository.Replies.CreateAsync(reply, cancellationToken);
        }
    }
}
