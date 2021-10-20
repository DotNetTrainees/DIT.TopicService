using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopicService.Data.Entities
{
    public class Topic : EntityBase
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Title must be 30 characters or less")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Text must be 1000 characters or less")]
        public string Text { get; set; }

        [Required]
        public int ReplyCount { get; set; }

        public IEnumerable<Reply> Replies { get; set; }
    }
}
