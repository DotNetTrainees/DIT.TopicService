using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TopicService.Api.Filters;
using TopicService.Application.Commands.TopicCommands;
using TopicService.Application.Models.DataTransferObjects.Incoming.Topic;
using TopicService.Application.Queries.TopicQueries;
using TopicService.Data.Entities;

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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTopicQuery());

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsFilter<Topic>))]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetTopicQuery
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(ValidateModelFilter))]
        public async Task<IActionResult> Create([FromBody] CreateTopicDTO dto)
        {
            var result = await _mediator.Send(
                new CreateTopicCommand
                {
                    Topic = dto
                });

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsFilter<Topic>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(
                new DeleteTopicCommand
                {
                    Id = id
                });

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [ServiceFilter(typeof(ValidateEntityExistsFilter<Topic>))]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTopicDTO dto)
        {
            var result = await _mediator.Send(
                new UpdateTopicCommand
                {
                    Id = id,
                    Topic = dto
                });

            return Ok(result);
        }
    }
}
