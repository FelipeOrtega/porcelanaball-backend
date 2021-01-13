using FluentValidation;
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
        public JsonReturn Get(int pagina, int itensPorPagina)
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
        public JsonReturn Post([FromBody]ProdutoCategoria produtoCategoria)
        {
            if (produtoCategoria == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(produtoCategoria, options => options.IncludeRuleSets("insert"));

            if (results.IsValid)
                return ReturnJson(_service.Insert(produtoCategoria));
            else
                return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody]ProdutoCategoria produtoCategoria)
        {
            if (produtoCategoria == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(produtoCategoria, options => options.IncludeRuleSets("update"));

            if (results.IsValid)
                return ReturnJson(_service.Update(produtoCategoria));
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