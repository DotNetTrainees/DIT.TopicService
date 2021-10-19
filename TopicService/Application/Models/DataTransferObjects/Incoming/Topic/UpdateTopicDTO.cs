using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopicService.Application.Models.DataTransferObjects.Incoming.Topic
{
    public class UpdateTopicDTO
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Title must be 30 characters or less")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }
    }
}
