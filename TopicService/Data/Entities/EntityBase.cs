using System;
using System.ComponentModel.DataAnnotations;

namespace TopicService.Data.Entities
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        DateTime Date { get; set; }
    }

    public abstract class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
