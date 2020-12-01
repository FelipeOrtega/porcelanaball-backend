using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using PB.Utils;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "manager")]
        public JsonReturn Get()
        {
            return RetornaJson(_service.Get());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get(int id)
        {
            return RetornaJson(_service.Get(id));
        }

        [HttpPost]
        public JsonReturn Post([FromBody] Object inputModel)
        {
            string json = inputModel.ToString();
            PB.Domain.Aluno aluno = JsonConvert.DeserializeObject<PB.Domain.Aluno>(json);
            return RetornaJson(_service.Insert(aluno));
        }

        [HttpPut("{id}")]
        public JsonReturn Put(int id,[FromBody] Object inputModel)
        {
            string json = inputModel.ToString();
            PB.Domain.Aluno aluno = JsonConvert.DeserializeObject<PB.Domain.Aluno>(json);
            if (aluno.codigo != id)
            {
                _notificationContext.AddNotification("Codigo do aluno difere do corpo da requisicao.");
                return RetornaJson(_notificationContext, (int)HttpStatusCode.BadRequest);
            }
            return RetornaJson(_service.Update(aluno));
        }

        [HttpDelete("{id}")]
        public JsonReturn Delete(int id, [FromBody] Object inputModel)
        {
            string json = inputModel.ToString();
            PB.Domain.Aluno aluno = JsonConvert.DeserializeObject<PB.Domain.Aluno>(json);
            if (aluno.codigo != id)
            {
                _notificationContext.AddNotification("Codigo do aluno difere do corpo da requisicao.");
                return RetornaJson(_notificationContext, (int)HttpStatusCode.BadRequest);
            }
            return RetornaJson(_service.Delete(aluno));
        }
    }
}
