using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteWebAPI.Models
{
    public class UserToken
    {
        public string UserName { get; set; }
        public string Senha { get; set; }
        public DateTime Data { get; set; }
    }
}