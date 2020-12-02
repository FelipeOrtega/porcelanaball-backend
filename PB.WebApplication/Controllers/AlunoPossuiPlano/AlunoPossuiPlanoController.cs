using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class AlunoPossuiPlanoController : ApiBase
    {
        private readonly IAlunoPossuiPlanoService _service;

        public AlunoPossuiPlanoController(NotificationContext notificationContext, IAlunoPossuiPlanoService service)
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
        public JsonReturn Post([FromBody]AlunoPossuiPlano alunoPossuiPlano)
        {
            return RetornaJson(_service.Insert(alunoPossuiPlano));
        }

        [HttpPut]
        public JsonReturn Put([FromBody]AlunoPossuiPlano alunoPossuiPlano)
        {
            return RetornaJson(_service.Update(alunoPossuiPlano));
        }

        [HttpDelete]
        public JsonReturn Delete([FromBody]AlunoPossuiPlano alunoPossuiPlano)
        {
            return RetornaJson(_service.Delete(alunoPossuiPlano));
        }
    }
}