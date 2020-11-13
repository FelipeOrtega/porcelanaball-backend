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
        public JsonReturn Post([FromBody] Object inputModel)
        {
     
           PB.Domain.Aluno aluno = (PB.Domain.Aluno) inputModel;

           return RetornaJson(_service.Insert(aluno));
        }

        [HttpPut("{id}")]
        public JsonReturn Put([FromBody] Object inputModel)
        {
            PB.Domain.Aluno aluno = (PB.Domain.Aluno)inputModel;

            return RetornaJson(_service.Update(aluno));
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete([FromBody] Object inputModel)
        {

            PB.Domain.Aluno aluno = (PB.Domain.Aluno)inputModel;

            return RetornaJson(_service.Delete(aluno));
        }
    }
}
