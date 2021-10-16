using System;

namespace TopicService.Data.Entities
{
    public interface IEntityBase
    {
        public Guid Id { get; set; }
    }

    public abstract class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
    }
}
