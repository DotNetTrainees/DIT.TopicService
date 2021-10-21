using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Infrastructure;

namespace TopicService.Application.Commands.TopicCommands
{
    public class DeleteTopicCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand>
    {
        private readonly IRepositoryManager _repository;

        public DeleteTopicCommandHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Topics.GetTopicByIdAsync(request.Id, true);
            await _repository.Topics.DeleteAsync(result, cancellationToken);
            return Unit.Value;
        }
    }
}
