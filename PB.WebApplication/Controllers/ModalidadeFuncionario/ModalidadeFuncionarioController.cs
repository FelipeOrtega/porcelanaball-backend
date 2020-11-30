using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class ModalidadeFuncionarioController : ApiBase
    {
        private readonly IModalidadeFuncionarioService _service;

        public ModalidadeFuncionarioController(NotificationContext notificationContext, IModalidadeFuncionarioService service)
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
        public JsonReturn Create([FromBody]ModalidadeFuncionario modalidadeFuncionario)
        {
            return RetornaJson(_service.Insert(modalidadeFuncionario));
        }

        [HttpPut]
        public JsonReturn Update([FromBody]ModalidadeFuncionario modalidadeFuncionario)
        {
            return RetornaJson(_service.Update(modalidadeFuncionario));
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete(int id)
        {
            return RetornaJson(_service.Delete(id));
        }
    }
}