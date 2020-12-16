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
    public class ProdutoCategoriaController : ApiBase
    {
        private readonly IProdutoCategoriaService _service;
        private readonly IValidator<ProdutoCategoria> _validator;

        public ProdutoCategoriaController(NotificationContext notificationContext, IProdutoCategoriaService service, IValidator<ProdutoCategoria> validator)
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
        public JsonReturn Post([FromBody]ProdutoCategoria produtoCategoria)
        {
            if (produtoCategoria == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(produtoCategoria, ruleSet: "insert");

            if (results.IsValid)
                return RetornaJson(_service.Insert(produtoCategoria));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]ProdutoCategoria produtoCategoria)
        {
            if (produtoCategoria == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(produtoCategoria, ruleSet: "update");

            if (results.IsValid)
                return RetornaJson(_service.Update(produtoCategoria));
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