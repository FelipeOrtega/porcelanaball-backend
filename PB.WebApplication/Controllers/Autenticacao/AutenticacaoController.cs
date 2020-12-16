using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.Service;
using Microsoft.AspNetCore.Authorization;
using PB.WebApplication.Core;
using System.Net;
using PB.Domain.Notifications;
using PB.Service.Interface;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class AutenticacaoController : ApiBase
    {
        private readonly IUserService _service;
        private readonly IValidator<User> _validator;

        public AutenticacaoController(NotificationContext notificationContext, IUserService service, IValidator<User> validator)
        {
            _service = service;
            _notificationContext = notificationContext;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = "manager")]
        public JsonReturn Get()
        {
            return RetornaJson(_service.Get());
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonReturn Post([FromBody] User user)
        {
            var userValidate = _service.Get(user);

            if (userValidate == null)
                return RetornaJson(userValidate, (int)HttpStatusCode.Forbidden);

            var token = TokenService.GenerateToken(userValidate);

            userValidate.password = "";

            var data = new { user = userValidate, token = token };
   
            return RetornaJson(data);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        public JsonReturn Put([FromBody] User user)
        {
            if (user == null)
                return RetornaJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(user, ruleSet: "update");

            if (results.IsValid)
                return RetornaJson(_service.Update(user));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public JsonReturn Delete(int id)
        {
            return RetornaJson(_service.Delete(id));
        }

    }
}
