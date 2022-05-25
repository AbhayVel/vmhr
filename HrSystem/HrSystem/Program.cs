using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem
{
    public class Program
    {
      public static void Main(string[] args)
      {
         CreateHostBuilder(args).Build().Run();
      }
        //Fluaint API-> 
        //Chain of responsibility prinsiple 
      public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<MainStartUp>();
                });// 
    }
}
