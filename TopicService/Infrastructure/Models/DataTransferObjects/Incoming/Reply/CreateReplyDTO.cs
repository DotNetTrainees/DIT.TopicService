using System;
using System.ComponentModel.DataAnnotations;

namespace TopicService.Infrastructure.Models.DataTransferObjects.Incoming.Reply
{
    public class CreateReplyDTO
    {
        [Required]
        public Guid TopicId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }
    }
}
