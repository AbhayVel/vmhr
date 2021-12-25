using HREntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRDB
{
    public class HrSystemDBContext : DbContext
    {
        public object applications;

        private string _connectionString { get; set; }
        public HrSystemDBContext() : base()
        {
            _connectionString = @"Data Source=DESKTOP-2DKE6C9\SQLEXPRESS  ;Initial Catalog=HRSystem;Integrated Security=True";
        }


        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
       

        public DbSet<User> Users { get; set; }

        public DbSet<Vacancy> vacancies { get; set; }
        
        public DbSet<Application> application { get; set; }


    }
}
