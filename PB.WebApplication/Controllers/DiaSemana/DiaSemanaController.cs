using System.Net;
using Microsoft.AspNetCore.Mvc;
using PB.Domain.Notifications;
using PB.Service.Interface;
using PB.WebApplication.Core;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using PB.Domain;
using FluentValidation.Results;
using X.PagedList;
using System;
using PB.Domain.Enum;
using System.Linq;

namespace PB.WebApplication.Controllers
{
    [Route("[controller]")]

    public class DiaSemanaController : ApiBase
    {

        public DiaSemanaController(NotificationContext notificationContext) 
        {
            _notificationContext = notificationContext;
        }

        [HttpGet]
        [Authorize(Roles = "manager, employee")]
        public JsonReturn Get()
        {
           return ReturnJson(new DescriptionAttributes<DiaSemana>().Descriptions.ToList());
        }

    }
}
