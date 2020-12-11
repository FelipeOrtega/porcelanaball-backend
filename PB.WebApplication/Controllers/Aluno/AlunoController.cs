using System.Net;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using PB.Domain;
using FluentValidation.Results;

namespace PB.WebApplication.Controllers
{
    [Route("Aluno")]

    public class AlunoController : ApiBase
    {
        private readonly IAlunoService _service;
        private readonly IValidator<Aluno> _validator;

        public AlunoController(NotificationContext notificationContext, IAlunoService service, IValidator<Aluno> validator)
        {
            _notificationContext = notificationContext;
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = "manager")]
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
        public JsonReturn Post([FromBody]Aluno aluno)
        {
            if (aluno == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(aluno, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(aluno));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public JsonReturn Put([FromBody]Aluno aluno)
        {
            if (aluno == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(aluno, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(aluno));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete(int id, [FromBody] PB.Domain.Aluno aluno)
        {
            if (aluno.codigo != id)
            {
                _notificationContext.AddNotification("Codigo do aluno difere do corpo da requisicao.");
                return RetornaJson(_notificationContext, (int)HttpStatusCode.BadRequest);
            }
            return RetornaJson(_service.Delete(aluno));
        }
    }
}
