using HREntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRDB
{
    public class HrSystemDBContext : DbContext
    {
        private string _connectionString { get; set; }
        public HrSystemDBContext() : base()
        {
            _connectionString = @"Data Source=DESKTOP-C0FBNF9\SQLEXPRESS;Initial Catalog=HRSystem;Integrated Security=True";
        }


        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
       

        public DbSet<User> Users { get; set; }


    }
}
