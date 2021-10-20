using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Infrastructure.Models.DataTransferObjects.Incoming.Topic;
using TopicService.Data.Entities;
using TopicService.Infrastructure;

namespace TopicService.Application.Commands.TopicCommands
{
    public class CreateTopicCommand : IRequest<Topic>
    {
        public CreateTopicDTO Topic { get; set; }
    }

    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, Topic>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CreateTopicCommandHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Topic> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = _mapper.Map<Topic>(request.Topic);

            topic.Id = Guid.NewGuid();
            topic.Date = DateTime.Now;

            return await _repository.Topics.CreateAsync(topic, cancellationToken);
        }
    }
}
