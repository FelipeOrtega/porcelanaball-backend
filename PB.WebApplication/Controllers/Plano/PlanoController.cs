using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using System.Net;

namespace PB.WebApplication.Controllers
{
    [Route("Plano")]
    public class PlanoController : ApiBase
    {
        private readonly IPlanoService _service;
        private readonly IValidator<Plano> _validator;

        public PlanoController(NotificationContext notificationContext, IPlanoService service, IValidator<Plano> validator)
        {
            _notificationContext = notificationContext;
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public JsonReturn Get()
        {
            return RetornaJson(_service.Get());
        }

        [HttpGet("{id}")]
        public JsonReturn Get(int id)
        {
            return RetornaJson(_service.Get(id));
        }

        [HttpPost]
        public JsonReturn Create([FromBody]Plano plano)
        {
            if (plano == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(plano, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(plano));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public JsonReturn Update([FromBody]Plano plano)
        {
            if (plano == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(plano, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(plano));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete(int id)
        {
            return RetornaJson(_service.Delete(id));
        }
    }
}
