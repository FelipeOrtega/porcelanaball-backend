using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers
{
    [Route("Funcionario")]
    public class FuncionarioController : ApiBase
    {
        private readonly IFuncionarioService _service;

        public FuncionarioController(NotificationContext notificationContext, IFuncionarioService service)
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
        public JsonReturn Create([FromBody]PB.Domain.Funcionario funcionario)
        {
            return RetornaJson(_service.Insert(funcionario));
        }

        [HttpPut]
        public JsonReturn Update([FromBody]PB.Domain.Funcionario funcionario)
        {
            return RetornaJson(_service.Update(funcionario));
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete(int codigo)
        {
            return RetornaJson(_service.Delete(codigo));
        }
    }
}
