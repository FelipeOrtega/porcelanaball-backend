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
    public class AlunoPossuiPlanoController : ApiBase
    {
        private readonly IAlunoPossuiPlanoService _service;
        private readonly IValidator<AlunoPossuiPlano> _validator;

        public AlunoPossuiPlanoController(NotificationContext notificationContext, 
            IAlunoPossuiPlanoService service, 
            IValidator<AlunoPossuiPlano> validator)
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
        public JsonReturn Post([FromBody]AlunoPossuiPlano alunoPossuiPlano)
        {
            if (alunoPossuiPlano == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(alunoPossuiPlano, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(alunoPossuiPlano));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]AlunoPossuiPlano alunoPossuiPlano)
        {
            if (alunoPossuiPlano == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(alunoPossuiPlano, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(alunoPossuiPlano));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Authorize(Roles = "manager")]
        public JsonReturn Delete([FromBody]AlunoPossuiPlano alunoPossuiPlano)
        {
            return RetornaJson(_service.Delete(alunoPossuiPlano));
        }
    }
}