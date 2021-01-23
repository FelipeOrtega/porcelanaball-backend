using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using System.Collections.Generic;
using System.Net;
using X.PagedList;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class EquipeAlunoController : ApiBase
    {
        private readonly IEquipeAlunoService _service;
        private readonly IValidator<EquipeAluno> _validator;

        public EquipeAlunoController(NotificationContext notificationContext, IEquipeAlunoService service, IValidator<EquipeAluno> validator)
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
        public JsonReturn Post([FromBody]EquipeAluno equipeAluno)
        {
            if (equipeAluno == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(equipeAluno, options => options.IncludeRuleSets("insert"));

            if (results.IsValid)
                return ReturnJson(_service.Insert(equipeAluno));
            else
                return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public JsonReturn Post([FromBody] List<EquipeAluno> equipeAlunos)
        {
            if (equipeAlunos == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            foreach(EquipeAluno equipeAluno in equipeAlunos)
            {
                ValidationResult results = _validator.Validate(equipeAluno, options => options.IncludeRuleSets("insert"));

                if (results.IsValid)
                    return ReturnJson(_service.Insert(equipeAluno));
                else
                    return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
            }

            return ReturnJson(0, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]EquipeAluno equipeAluno)
        {
            if (equipeAluno == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(equipeAluno, options => options.IncludeRuleSets("update"));

            if (results.IsValid)
                return ReturnJson(_service.Update(equipeAluno));
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
