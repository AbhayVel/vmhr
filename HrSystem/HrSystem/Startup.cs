using HRDB;
using HRRepository;
using HRService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem
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
            services.AddControllersWithViews();


            services.AddScoped<HrSystemDBContext, HrSystemDBContext>();
            

            services.AddScoped<StageRepository, StageRepository>();
            services.AddScoped<VacancyRepository, VacancyRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<ApplicationService, ApplicationService>();
            services.AddScoped<VacancyService, VacancyService>();
            services.AddScoped<StageService, StageService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //1 .Use <-Imp 
            //2. run 
            //3. Map 

            //1. Request 
            //2. Response
            //3. Session 
            //4. Cookie -> Server 
            //5. Application 
            //6. Server
            //--------
            //7. Error 
            //8. User 



            ////////app.Map("/Applications/Index", (app) =>
            ////////{

            ////////    app.Use(async (context, next) =>
            ////////    {
            ////////        await next();
            ////////    });

            ////////});
            //app.UseWhen((x) => (x.Request.Path.ToString().ToLower().Equals("/applications/index")
            //    && x.Request.Form["IdSearch"].FirstOrDefault() == "-1"), async (n) =>
            //    {


            //        await context.Response.WriteAsync("I am rom middle ware direct return");
            //    });
         
            //app.Use(async (context, next) =>
            //{
            //    int i = 1;
            //    if (context.Request.Path.ToString().ToLower().Equals("/applications/index")  
            //    && context.Request.Form["IdSearch"].FirstOrDefault()=="-1")                
            //    {

            //        await context.Response.WriteAsync("I am rom middle ware direct return");


            //    } else
            //    {
            //        await next();
            //    }
                
            //    i = i + 1;

            //});


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("I am From middle ware run");

            //});

            app.UseRouting();

            app.UseAuthorization();


            //app.UseMvc((x) =>
            //{
            //    x.F
            //})
            app.UseEndpoints(endpoints =>
            {

               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Applications}/{action=Index}/{id?}");
            });
        }
    }
}
