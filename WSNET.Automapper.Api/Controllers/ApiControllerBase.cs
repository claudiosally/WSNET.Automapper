using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WSNET.Automapper.Domain.Services.Interface;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WSNET.Automapper.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json", "application/problem+json")]
    [ProducesResponseType(Status500InternalServerError)]
    [ProducesResponseType(Status503ServiceUnavailable)]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly INotification _notification;

        protected ApiControllerBase(INotification notification)
        {
            _notification = notification;
        }

        /// <summary>
        /// Retorna o BadRequest adicionando os erros do notification como validation problem
        /// </summary>
        protected new ActionResult BadRequest()
        {
            foreach (ValidationFailure e in _notification.GetFailures())
                ModelState.AddModelError(e.PropertyName, string.Format(e.ErrorMessage, e.PropertyName));

            if (ModelState.IsValid)
                return base.BadRequest();

            return ValidationProblem(statusCode: Status400BadRequest, modelStateDictionary: ModelState);
        }

        /// <summary>
        /// Retorna o UnprocessableEntity adicionando os erros do notification como validation problem
        /// </summary>
        protected new ActionResult UnprocessableEntity()
        {
            foreach (ValidationFailure e in _notification.GetFailures())
                ModelState.AddModelError(e.PropertyName, string.Format(e.ErrorMessage, e.PropertyName));

            if (ModelState.IsValid)
                return base.UnprocessableEntity();

            return ValidationProblem(statusCode: Status422UnprocessableEntity, modelStateDictionary: ModelState);
        }
    }
}
