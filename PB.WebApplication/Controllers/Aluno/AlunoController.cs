using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PB.WebApplication.Controllers.Aluno
{
    [Route("Aluno")]
    public class AlunoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Aluno aluno = new Aluno();
            aluno.nome = "Diego";
            aluno.idade = 27;

            return Ok(aluno);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Aluno aluno = new Aluno();
            aluno.nome = "Jubileu";
            aluno.idade = 30;

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Aluno inputModel)
        {
            return Ok(inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Aluno inputModel)
        {
            return Ok(inputModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Aluno aluno = new Aluno();
            aluno.nome = "Jubileu";
            aluno.idade = 30;
            return Ok(aluno);
        }
    }
}
