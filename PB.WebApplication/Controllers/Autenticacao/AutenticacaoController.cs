using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Domain;
using PB.InfraEstrutura.Data.Repository;
using PB.Service;
using Microsoft.AspNetCore.Authorization;
using PB.WebApplication.Core;
using System.Net;
using PB.Domain.Notifications;
using PB.Service.Interface;
using FluentValidation;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]
    public class AutenticacaoController : ApiBase
    {
        private readonly IUserService _serviceUser;


        public AutenticacaoController(NotificationContext notificationContext, IUserService serviceUser)
        {
            _serviceUser = serviceUser;
            _notificationContext = notificationContext;
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonReturn Post([FromBody] User model)
        {
            var user = _serviceUser.Get(model);

            if (user == null)
                return RetornaJson(user, (int)HttpStatusCode.Forbidden);

            var token = TokenService.GenerateToken(user);

            user.password = "";

            var data = new { user = user, token = token };
   
            return RetornaJson(data);
        }
    }
}
