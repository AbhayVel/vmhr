using HREntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRDB
{
    public class HrSystemDBContext : DbContext
    {

        public int Count = 0; //instace variable 
        private string _connectionString { get; set; }
        public HrSystemDBContext() : base()
        {


            _connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = "Data Source=DESKTOP-0K1J33K\\SQLEXPRESS;Initial Catalog=HRSystem;Integrated Security=True";
            }

        }

        public HrSystemDBContext(string connectionString) : base()
        {


            _connectionString = connectionString;
            if(string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = "Data Source=DESKTOP-0K1J33K\\SQLEXPRESS;Initial Catalog=HRSystem;Integrated Security=True";
            }

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }

        public DbSet<Vacancy> Vacancies { get; set; }


        public DbSet<Stage> Stages { get; set; }
        public DbSet<LoginUser> LoginUser { get; set; }

        public DbSet<Feed> Feeds { get; set; }

        public DbSet<FeedType> FeedType { get; set; }



        public DbSet<TimeSheet> TimeSheet { get; set; }





    }
}
