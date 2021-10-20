using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Infrastructure;

namespace TopicService.Application.Commands.ReplyCommands
{
    public class DeleteReplyCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand>
    {
        private readonly IRepositoryManager _repository;

        public DeleteReplyCommandHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = await _repository.Replies.GetAsync(request.Id, cancellationToken);
            var topic = await _repository.Topics.GetAsync(reply.TopicId, cancellationToken);

            await _repository.Replies.DeleteAsync(request.Id, cancellationToken);

            topic.ReplyCount--;
            await _repository.Topics.UpdateAsync(topic, cancellationToken);

            return Unit.Value;
        }
    }
}
