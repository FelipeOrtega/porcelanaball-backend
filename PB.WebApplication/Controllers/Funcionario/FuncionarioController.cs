using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PB.WebApplication.Controllers.Funcionario
{
    [Route("Funcionario")]
    public class FuncionarioController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(null);
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
