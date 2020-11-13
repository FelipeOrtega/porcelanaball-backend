using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;

namespace PB.WebApplication.Controllers.Funcionario
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
        public async Task<JsonReturn> Get()
        {
            return RetornaJson(_service.Get());
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
