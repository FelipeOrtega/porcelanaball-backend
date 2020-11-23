using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class ProdutoCategoriaController : ApiBase
    {
        private readonly IProdutoCategoriaService _service;

        public ProdutoCategoriaController(NotificationContext notificationContext, IProdutoCategoriaService service)
        {
            _notificationContext = notificationContext;
            _service = service;
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
        public JsonReturn Post([FromBody]ProdutoCategoria modalidade)
        {
            return RetornaJson(_service.Insert(modalidade));
        }

        [HttpPut]
        public JsonReturn Put([FromBody]ProdutoCategoria modalidade)
        {
            return RetornaJson(_service.Update(modalidade));
        }

        [HttpDelete]
        public JsonReturn Delete([FromBody]ProdutoCategoria modalidade)
        {
            return RetornaJson(_service.Delete(modalidade));
        }
    }
}