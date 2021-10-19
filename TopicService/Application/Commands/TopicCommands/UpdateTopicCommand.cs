using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopicService.Application.Models.DataTransferObjects.Incoming.Topic;
using TopicService.Data.Entities;
using TopicService.Infrastructure;

namespace TopicService.Application.Commands.TopicCommands
{
    public class UpdateTopicCommand : IRequest<Topic>
    {
        public Guid Id { get; set; }
        public UpdateTopicDTO Topic { get; set; }
    }

    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, Topic>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UpdateTopicCommandHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<Topic> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = await _repository.Topics.GetAsync(request.Id, cancellationToken);

            _mapper.Map(request.Topic, topic);

            var result = await _repository.Topics.UpdateAsync(topic, cancellationToken);

            return result;
        }
    }
}
