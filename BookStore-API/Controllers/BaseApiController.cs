using AutoMapper;
using BookStore_API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly ILoggerService _logger;
        protected readonly IMapper _mapper;

        public BaseApiController(ILoggerService logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        protected ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact to the Administrator");
        }

        protected string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }
    }
}
