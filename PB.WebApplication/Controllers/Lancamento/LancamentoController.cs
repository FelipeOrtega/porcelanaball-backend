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
    public class LancamentoController : ApiBase
    {
        private readonly ILancamentoService _service;
        private readonly IValidator<Lancamento> _validator;

        public LancamentoController(NotificationContext notificationContext, ILancamentoService service, IValidator<Lancamento> validator)
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
        public JsonReturn Post([FromBody]Lancamento lancamento)
        {
            if (lancamento == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(lancamento, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(lancamento));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public JsonReturn Put([FromBody]Lancamento lancamento)
        {
            if (lancamento == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(lancamento, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(lancamento));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public JsonReturn Delete([FromBody]Lancamento lancamento)
        {
            return RetornaJson(_service.Delete(lancamento));
        }
    }
}