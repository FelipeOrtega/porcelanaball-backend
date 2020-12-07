using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class AlunoTreinoController : ApiBase
    {
        private readonly IAlunoTreinoService _service;

        public AlunoTreinoController(NotificationContext notificationContext, IAlunoTreinoService service)
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
        public JsonReturn Post([FromBody]AlunoTreino alunoTreino)
        {
            return RetornaJson(_service.Insert(alunoTreino));
        }

        [HttpPut]
        public JsonReturn Put([FromBody]AlunoTreino alunoTreino)
        {
            return RetornaJson(_service.Update(alunoTreino));
        }

        [HttpDelete]
        public JsonReturn Delete([FromBody]AlunoTreino alunoTreino)
        {
            return RetornaJson(_service.Delete(alunoTreino));
        }
    }
}