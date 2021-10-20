using System;
using System.Collections.Generic;
using System.Text;

namespace TopicService.Application.Models.RequestFeatures.Reply
{
    public class ReplyParameters : RequestParameters
    {
        public ReplyParameters()
        {
            OrderBy = "date";
        }
    }
}
