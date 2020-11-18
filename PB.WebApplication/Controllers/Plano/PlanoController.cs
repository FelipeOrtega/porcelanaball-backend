using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("Plano")]
    public class PlanoController : ApiBase
    {
        private readonly IPlanoService _service;

        public PlanoController(NotificationContext notificationContext, IPlanoService service)
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
        public JsonReturn Create([FromBody]Plano plano)
        {
            return RetornaJson(_service.Insert(plano));
        }

        [HttpPut]
        public JsonReturn Update([FromBody]Plano plano)
        {
            return RetornaJson(_service.Update(plano));
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete(int id)
        {
            return RetornaJson(_service.Delete(id));
        }
    }
}
