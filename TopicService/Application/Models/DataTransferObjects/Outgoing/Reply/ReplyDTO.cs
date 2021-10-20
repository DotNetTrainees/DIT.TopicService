using System;
using System.ComponentModel.DataAnnotations;

namespace TopicService.Application.Models.DataTransferObjects.Outgoing.Reply
{
    public class ReplyDTO
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
