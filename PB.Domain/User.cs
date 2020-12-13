using PB.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PB.Domain
{
    public class User : EntityBase
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
