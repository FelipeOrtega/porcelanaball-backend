using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class ModalidadeController : ApiBase
    {
        private readonly IModalidadeService _service;

        public ModalidadeController(NotificationContext notificationContext, IModalidadeService service)
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
        public JsonReturn Post([FromBody]Modalidade modalidade)
        {
            return RetornaJson(_service.Insert(modalidade));
        }

        [HttpPut]
        public JsonReturn Put([FromBody]Modalidade modalidade)
        {
            return RetornaJson(_service.Update(modalidade));
        }

        [HttpDelete]
        public JsonReturn Delete([FromBody]Modalidade modalidade)
        {
            return RetornaJson(_service.Delete(modalidade));
        }
    }
}