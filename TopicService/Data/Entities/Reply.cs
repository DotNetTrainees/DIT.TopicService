using System;
using System.ComponentModel.DataAnnotations;

namespace TopicService.Data.Entities
{
    public class Reply : EntityBase
    {
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
