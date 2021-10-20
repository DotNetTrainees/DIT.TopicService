using AutoMapper;
using System.Linq;
using TopicService.Infrastructure.Models.DataTransferObjects.Incoming.Reply;
using TopicService.Infrastructure.Models.DataTransferObjects.Incoming.Topic;
using TopicService.Infrastructure.Models.DataTransferObjects.Outgoing.Reply;
using TopicService.Infrastructure.Models.DataTransferObjects.Outgoing.Topic;
using TopicService.Data.Entities;

namespace TopicService.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTopicDTO, Topic>();
            CreateMap<UpdateTopicDTO, Topic>();
            CreateMap<Topic, TopicDTO>()
                .ForMember(x => x.ReplyCount, opt => opt.MapFrom(y => y.Replies.Count()));

            CreateMap<CreateReplyDTO, Reply>();
            CreateMap<UpdateReplyDTO, Reply>();
            CreateMap<Reply, ReplyDTO>();
        }
    }
}
