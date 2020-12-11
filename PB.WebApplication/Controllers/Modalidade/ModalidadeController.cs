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
    [Route("[controller]")]
    public class ModalidadeController : ApiBase
    {
        private readonly IModalidadeService _service;
        private readonly IValidator<Modalidade> _validator;

        public ModalidadeController(NotificationContext notificationContext, IModalidadeService service, IValidator<Modalidade> validator)
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
        public JsonReturn Post([FromBody]Modalidade modalidade)
        {
            if (modalidade == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(modalidade, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(modalidade));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public JsonReturn Put([FromBody]Modalidade modalidade)
        {
            if (modalidade == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(modalidade, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(modalidade));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public JsonReturn Delete([FromBody]Modalidade modalidade)
        {
            return RetornaJson(_service.Delete(modalidade));
        }
    }
}