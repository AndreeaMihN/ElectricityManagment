using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        //private IMediator _mediator;
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //protected string AuthorizedUserId => HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
        //                       .Select(c => c.Value).SingleOrDefault();
    }
}