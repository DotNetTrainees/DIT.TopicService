﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TopicService.Application.Models.DataTransferObjects.Incoming.Topic
{
    public class CreateTopicDTO
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Title must be 30 characters or less")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }
    }
}
