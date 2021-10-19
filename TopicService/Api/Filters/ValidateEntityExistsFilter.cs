using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using TopicService.Data.Entities;
using TopicService.Infrastructure;

namespace TopicService.Api.Filters
{
    public class ValidateEntityExistsFilter<TEntity> : IActionFilter where TEntity : class, IEntityBase
    {
        private readonly DatabaseContext _context;

        public ValidateEntityExistsFilter(DatabaseContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Guid id;
            if (context.ActionArguments.ContainsKey("id"))
                id = (Guid)context.ActionArguments["id"];
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
                return;
            }

            if (id == null)
            {
                context.Result = new BadRequestObjectResult("Id parameter was null");
                return;
            }

            var entity = _context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                context.Result = new NotFoundResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
