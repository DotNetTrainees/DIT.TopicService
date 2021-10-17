using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopicService.Application.Commands.TopicCommands;
using TopicService.Application.Models.DataTransferObjects.Incoming.Topic;

namespace TopicService.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("v{version:apiVersion}/topic")]
    public class TopicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TopicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTopicDTO dto)
        {
            var result = await _mediator.Send(
                new CreateTopicCommand
                {
                    Topic = dto
                });

            return Ok(result);
        }
    }
}
