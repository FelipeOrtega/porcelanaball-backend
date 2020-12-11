using System;
using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("Produto")]
    public class ProdutoController : ApiBase
    {
        private readonly IProdutoService _service;
        private readonly IValidator<Produto> _validator;

        public ProdutoController(NotificationContext notificationContext, IProdutoService service, IValidator<Produto> validator)
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
        public JsonReturn Post([FromBody]Produto produto)
        {
            if (produto == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(produto, ruleSet: "insert");
            if (results.IsValid)
                return RetornaJson(_service.Insert(produto));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public JsonReturn Put([FromBody]Produto produto)
        {
            if (produto == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(produto, ruleSet: "update");
            if (results.IsValid)
                return RetornaJson(_service.Update(produto));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete([FromBody] Object inputModel)
        {

            PB.Domain.Produto produto = (PB.Domain.Produto)inputModel;

            return RetornaJson(_service.Delete(produto));
        }
    }
}
