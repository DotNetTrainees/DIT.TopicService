using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Infrastructure.Models.DataTransferObjects.Incoming.Reply;
using TopicService.Data.Entities;
using TopicService.Infrastructure;

namespace TopicService.Application.Commands.ReplyCommands
{
    public class UpdateReplyCommand : IRequest<Reply>
    {
        public Guid Id { get; set; }
        public UpdateReplyDTO Reply { get; set; }
    }

    public class UpdateReplyCommandHandler : IRequestHandler<UpdateReplyCommand, Reply>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UpdateReplyCommandHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<Reply> Handle(UpdateReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _repository.Replies.GetAsync(request.Id, cancellationToken);

            _mapper.Map(request.Reply, reply);

            var result = await _repository.Replies.UpdateAsync(reply, cancellationToken);

            return result;
        }
    }
}
