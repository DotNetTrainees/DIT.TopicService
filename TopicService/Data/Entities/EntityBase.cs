using System;

namespace TopicService.Data.Entities
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }

    public abstract class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
    }
}
