using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers.Aluno
{
    [Route("Aluno")]    
    public class AlunoController : ApiBase
    {
        private readonly IAlunoService _service;

        public AlunoController(NotificationContext notificationContext, IAlunoService service)
        {
            _notificationContext = notificationContext;
            _service = service;
        }

        [HttpGet]
        public async Task<JsonReturn> Get()
        {
            return RetornaJson(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(String codigo)
        {
            _notificationContext.AddNotification("notificação falha exemplo");
            return Ok(null);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Object inputModel)
        {
            return Ok(inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Object inputModel)
        {
            return Ok(inputModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(null);
        }
    }
}
