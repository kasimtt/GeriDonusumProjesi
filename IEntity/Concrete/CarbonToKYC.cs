﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
    public class CarbonToKYC : IEntity
    {
        public double CarbontoKYC { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
