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
    public class ModalidadeFuncionarioController : ApiBase
    {
        private readonly IModalidadeFuncionarioService _service;
        private readonly IValidator<ModalidadeFuncionario> _validator;

        public ModalidadeFuncionarioController(NotificationContext notificationContext, IModalidadeFuncionarioService service, IValidator<ModalidadeFuncionario> validator)
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
        public JsonReturn Post([FromBody]ModalidadeFuncionario modalidadeFuncionario)
        {
            if (modalidadeFuncionario == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(modalidadeFuncionario, ruleSet: "insert");

            if (results.IsValid)
                return RetornaJson(_service.Insert(modalidadeFuncionario));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]ModalidadeFuncionario modalidadeFuncionario)
        {
            if (modalidadeFuncionario == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(modalidadeFuncionario, ruleSet: "update");

            if (results.IsValid)
                return RetornaJson(_service.Update(modalidadeFuncionario));
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