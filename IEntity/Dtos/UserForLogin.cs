using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class UserForLogin:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
