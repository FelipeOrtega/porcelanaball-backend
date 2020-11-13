using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers.Produto
{
    [Route("Produto")]
    public class ProdutoController : ApiBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(NotificationContext notificationContext, IProdutoService service)
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
        public JsonReturn Get(int codigo)
        {

            return RetornaJson(_service.Get(codigo));
        }

        [HttpPost]
        public JsonReturn Post([FromBody] Object inputModel)
        {

            PB.Domain.Produto produto = (PB.Domain.Produto)inputModel;

            return RetornaJson(_service.Insert(produto));
        }

        [HttpPut("{id}")]
        public JsonReturn Put([FromBody] Object inputModel)
        {
            PB.Domain.Produto produto = (PB.Domain.Produto)inputModel;

            return RetornaJson(_service.Update(produto));
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete([FromBody] Object inputModel)
        {

            PB.Domain.Produto produto = (PB.Domain.Produto)inputModel;

            return RetornaJson(_service.Delete(produto));
        }
    }
}
