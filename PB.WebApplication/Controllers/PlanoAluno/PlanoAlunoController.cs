﻿using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using System.Net;
using X.PagedList;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class PlanoAlunoController : ApiBase
    {
        private readonly IPlanoAlunoService _service;
        private readonly IValidator<PlanoAluno> _validator;

        public PlanoAlunoController(NotificationContext notificationContext, IPlanoAlunoService service, IValidator<PlanoAluno> validator)
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
        public JsonReturn Post([FromBody]PlanoAluno alunoPossuiPlano)
        {
            if (alunoPossuiPlano == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(alunoPossuiPlano, options => options.IncludeRuleSets("insert"));

            if (results.IsValid)
                return ReturnJson(_service.Insert(alunoPossuiPlano));
            else
                return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]PlanoAluno alunoPossuiPlano)
        {
            if (alunoPossuiPlano == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(alunoPossuiPlano, options => options.IncludeRuleSets("update"));

            if (results.IsValid)
                return ReturnJson(_service.Update(alunoPossuiPlano));
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