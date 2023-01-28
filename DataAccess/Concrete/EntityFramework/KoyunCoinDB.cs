
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class KoyunCoinDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LENOVO\MSSQLSERVERKT;Database=KoyunCoinDB;Trusted_Connection=true");
        }

        public DbSet<CarbonToKYC> CarbonToKYC { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Garbage> Garbages { get; set; }
      

    }
}
