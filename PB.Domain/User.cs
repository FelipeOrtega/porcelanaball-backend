using System;
using System.Collections.Generic;
using System.Text;

namespace PB.Domain
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
