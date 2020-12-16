using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using System.Net;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class FuncionarioController : ApiBase
    {
        private readonly IFuncionarioService _service;
        private readonly IValidator<Funcionario> _validator;

        public FuncionarioController(NotificationContext notificationContext, IFuncionarioService service, IValidator<Funcionario> validator)
        {
            _notificationContext = notificationContext;
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get()
        {
            return RetornaJson(_service.Get());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get(int id)
        {
            return RetornaJson(_service.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public JsonReturn Post([FromBody]Funcionario funcionario)
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
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]Funcionario funcionario)
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
        [Authorize(Roles = "manager")]
        public JsonReturn Delete(int id)
        {
            return RetornaJson(_service.Delete(id));
        }
    }
}
