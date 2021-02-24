using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using System.Net;
using X.PagedList;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class QuadraController : ApiBase
    {
        private readonly IQuadraService _service;
        private readonly IValidator<Quadra> _validator;

        public QuadraController(NotificationContext notificationContext, IQuadraService service, IValidator<Quadra> validator)
        {
            _notificationContext = notificationContext;
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get()
        {
            return ReturnJson(_service.Get());
        }

        [HttpGet("byPage")]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn GetByPage(int pagina, int itensPorPagina)
        {
            return ReturnJson(_service.Get().ToPagedList(pagina, itensPorPagina));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get(int id)
        {
            return ReturnJson(_service.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public JsonReturn Post([FromBody]Quadra quadra)
        {
            if (quadra == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(quadra, options => options.IncludeRuleSets("insert"));

            if (results.IsValid)
                return ReturnJson(_service.Insert(quadra));
            else
                return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]Quadra quadra)
        {
            if (quadra == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(quadra, options => options.IncludeRuleSets("update"));

            if (results.IsValid)
                return ReturnJson(_service.Update(quadra));
            else
                return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public JsonReturn Delete(int id)
        {
            return ReturnJson(_service.Delete(id));
        }
    }
}