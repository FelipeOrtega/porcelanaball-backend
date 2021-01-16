using System.Net;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using PB.Domain;
using FluentValidation.Results;
using X.PagedList;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]

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
        public JsonReturn Post([FromBody]Aluno aluno)
        {
            if (aluno == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(aluno, options => options.IncludeRuleSets("insert"));


            if (results.IsValid)
                return ReturnJson(_service.Insert(aluno));
            else
                return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]Aluno aluno)
        {
            if (aluno == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(aluno, options => options.IncludeRuleSets("update"));

            if (results.IsValid)
                return ReturnJson(_service.Update(aluno));
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
