using AutoMapper;
using TopicService.Application.Models.DataTransferObjects.Incoming.Reply;
using TopicService.Application.Models.DataTransferObjects.Incoming.Topic;
using TopicService.Application.Models.DataTransferObjects.Outgoing.Reply;
using TopicService.Application.Models.DataTransferObjects.Outgoing.Topic;
using TopicService.Data.Entities;

namespace TopicService.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTopicDTO, Topic>();
            CreateMap<UpdateTopicDTO, Topic>();
            CreateMap<Topic, TopicDTO>();

            CreateMap<CreateReplyDTO, Reply>();
            CreateMap<UpdateReplyDTO, Reply>();
            CreateMap<Reply, ReplyDTO>();
        }
    }
}
