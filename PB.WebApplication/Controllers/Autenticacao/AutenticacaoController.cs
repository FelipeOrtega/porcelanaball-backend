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
using Microsoft.AspNetCore.Cors;

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
        [EnableCors("MyPolicy")]
        public JsonReturn Get()
        {
            return ReturnJson(_service.Get());
        }

        [HttpPost]
        [AllowAnonymous]
        [EnableCors("MyPolicy")]
        public JsonReturn Post([FromBody] User user)
        {
            var userValidate = _service.Get(user);

            if (userValidate == null)
                return ReturnJson(userValidate, (int)HttpStatusCode.Forbidden);

            var token = TokenService.GenerateToken(userValidate);

            userValidate.password = "";

            var data = new { user = userValidate, token = token };
   
            return ReturnJson(data);
        }

        [HttpPut]
        [Authorize(Roles = "manager")]
        [EnableCors("MyPolicy")]
        public JsonReturn Put([FromBody] User user)
        {
            if (user == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            ValidationResult results = _validator.Validate(user, options => options.IncludeRuleSets("update")); 

            if (results.IsValid)
                return ReturnJson(_service.Update(user));
            else
                return ReturnJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        [EnableCors("MyPolicy")]
        public JsonReturn Delete(int id)
        {
            return ReturnJson(_service.Delete(id));
        }

    }
}
