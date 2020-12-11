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
    [Route("Funcionario")]
    public class FuncionarioController : ApiBase
    {
        private readonly IFuncionarioService _service;
        private readonly IValidator<Funcionario> _validator;

        public FuncionarioController(NotificationContext notificationContext, 
            IFuncionarioService service, IValidator<Funcionario> validator)
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
        public JsonReturn Create([FromBody]Funcionario funcionario)
        {
            if (funcionario == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(funcionario, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(funcionario));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public JsonReturn Update([FromBody]Funcionario funcionario)
        {
            if (funcionario == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(funcionario, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(funcionario));
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
