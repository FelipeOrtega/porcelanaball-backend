using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Notifications;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers.Aluno
{
    [Route("Aluno")]
    public class AlunoController : ApiBase
    {
        public AlunoController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        [HttpGet]
        public async Task<JsonReturn> Get()
        {
            _notificationContext.AddNotification("notificação falha exemplo");
            return RetornaJson("ok");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

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
