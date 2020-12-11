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
    public class AlunoTreinoController : ApiBase
    {
        private readonly IAlunoTreinoService _service;
        private readonly IValidator<AlunoTreino> _validator;

        public AlunoTreinoController(NotificationContext notificationContext, IAlunoTreinoService service, IValidator<AlunoTreino> validator)
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
        public JsonReturn Post([FromBody]AlunoTreino alunoTreino)
        {
            if (alunoTreino == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(alunoTreino, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(alunoTreino));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]AlunoTreino alunoTreino)
        {
            if (alunoTreino == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(alunoTreino, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(alunoTreino));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Authorize(Roles = "manager")]
        public JsonReturn Delete([FromBody]AlunoTreino alunoTreino)
        {
            return RetornaJson(_service.Delete(alunoTreino));
        }
    }
}