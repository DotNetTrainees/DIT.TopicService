﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TopicService.Application.Commands.TopicCommands;
using TopicService.Application.Models.DataTransferObjects.Incoming.Topic;
using TopicService.Application.Queries.TopicQueries;

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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTopicDTO dto)
        {
            var result = await _mediator.Send(
                new CreateTopicCommand
                {
                    Topic = dto
                });

            return Ok(result);
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTopicQuery());

            return Ok(result);
        }
    }
}
