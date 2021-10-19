using System;
using System.ComponentModel.DataAnnotations;

namespace TopicService.Application.Models.DataTransferObjects.Outgoing.Topic
{
    public class TopicDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Title must be 30 characters or less")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
