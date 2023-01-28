using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class PersonalDtailsDto:IDto
    {
        //user ve customer join işlemi yapılır.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double Carbon { get; set; }
        public double KYC { get; set; }


    }
}
