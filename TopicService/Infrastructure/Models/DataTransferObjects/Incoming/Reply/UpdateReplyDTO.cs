using System.ComponentModel.DataAnnotations;

namespace TopicService.Infrastructure.Models.DataTransferObjects.Incoming.Reply
{
    public class UpdateReplyDTO
    {
        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }
    }
}
