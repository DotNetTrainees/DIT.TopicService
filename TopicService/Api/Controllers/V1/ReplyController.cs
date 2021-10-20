using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TopicService.Api.Filters;
using TopicService.Application.Commands.ReplyCommands;
using TopicService.Infrastructure.Models.DataTransferObjects.Incoming.Reply;
using TopicService.Infrastructure.Models.RequestFeatures.Reply;
using TopicService.Application.Queries.ReplyQueries;
using TopicService.Data.Entities;

namespace TopicService.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("v{version:apiVersion}/reply")]
    public class ReplyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReplyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] ReplyParameters parameters)
        {
            var result = await _mediator.Send(new GetAllReplyQuery());

            return Ok(result);
        }

        [HttpGet("get/{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsFilter<Reply>))]
        public async Task<IActionResult> Get(Guid? id)
        {
            var result = await _mediator.Send(new GetReplyQuery
            {
                Id = (Guid)id
            });

            return Ok(result);
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(ValidateModelFilter))]
        public async Task<IActionResult> Create([FromBody] CreateReplyDTO dto)
        {
            var result = await _mediator.Send(
                new CreateReplyCommand
                {
                    Reply = dto
                });

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsFilter<Reply>))]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var result = await _mediator.Send(
                new DeleteReplyCommand
                {
                    Id = (Guid)id
                });

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [ServiceFilter(typeof(ValidateModelFilter))]
        [ServiceFilter(typeof(ValidateEntityExistsFilter<Reply>))]
        public async Task<IActionResult> Update(Guid? id, [FromBody] UpdateReplyDTO dto)
        {
            var result = await _mediator.Send(
                new UpdateReplyCommand
                {
                    Id = (Guid)id,
                    Reply = dto
                });

            return Ok(result);
        }
    }
}
