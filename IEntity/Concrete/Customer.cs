using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
    public class Customer : IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public double Carbon { get; set; }
        public double KYC { get; set; }
        public int SHAId { get; set; }
    }
}
