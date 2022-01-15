using HRDB;
using HRRepository;
using HRService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystemApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();

            services.AddScoped<HrSystemDBContext, HrSystemDBContext>();


            services.AddScoped<StageRepository, StageRepository>();
            services.AddScoped<VacancyRepository, VacancyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<ApplicationService, ApplicationService>();
            services.AddScoped<VacancyService, VacancyService>();
            services.AddScoped<StageService, StageService>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
