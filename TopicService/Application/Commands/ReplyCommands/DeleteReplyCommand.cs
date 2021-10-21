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
            var result = await _repository.Replies.GetReplyByIdAsync(request.Id, true);
            await _repository.Replies.DeleteAsync(result, cancellationToken);
            return Unit.Value;
        }
    }
}
