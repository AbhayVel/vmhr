using HRDB;
using HRRepository;
using HRService;
using HrSystem.FIlters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem
{
    public class MainStartUp
    {

        static int isCount=0;
        public MainStartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
          .AddNewtonsoftJson().AddRazorRuntimeCompilation();

         services.AddControllersWithViews((options)=> {
             //   options.Filters.Add(new HRAuthrizationFiltter());
             //   options.Filters.Add(new HRExceptionFilter());
                options.Filters.Add(new HRActionFilter());
            });
            services.AddSession();

            services.AddAuthentication("cookies").
                AddCookie("cookies", x =>
                {
                    x.LoginPath = "/Users/Login";
                    x.LogoutPath = "/Users/logout";
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                });


            // services.AddScoped<HttpContext, HttpContext>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<HrSystemDBContext, HrSystemDBContext>();
            

            services.AddScoped<StageRepository, StageRepository>();
            services.AddScoped<VacancyRepository, VacancyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
         services.AddScoped<IApplicationRepository, ApplicationRepository>();

            services.AddScoped<TimeSheetRepository, TimeSheetRepository>();
            
            services.AddScoped<IFeedTypeRepository, FeedTypeRepository>();
            services.AddScoped<IFeedRepository, FeedRepository>();
            services.AddScoped<ApplicationService, ApplicationService>();
 
            services.AddScoped<VacancyService, VacancyService>();
            services.AddScoped<StageService, StageService>();
         services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFeedRepository, FeedRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string strPosition = "";

           // app.UseExceptionHandler("/Home/Error");

            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        strPosition = "I am in Box 1 Before";
            //        await next();
            //    }
            //    catch (Exception ex)
            //    {
            //        context.Response.Redirect("/Home/Error");
            //       await Task.CompletedTask;
            //    }


            //});
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

            app.Use(async (context, next) =>
            {
                Console.WriteLine("I am start");
                strPosition = "I am in Box 1 Before";
                if (isCount == 0)
                {
                    isCount = isCount + 1;
                   // throw new Exception("I am in EXception");
                }
                await next();
                strPosition = "I am in Box 1 After";
                Console.WriteLine("I am End");
            });

           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
           

            app.Use(async (context, next) =>
            {
            //    Console.WriteLine("I am start");
                strPosition = "I am in Box 2 Before";
                await next();
                strPosition = "I am in Box 2 After";
              //  Console.WriteLine("I am End");
            });

            app.Use(async (context, next) =>
            {
              //  Console.WriteLine("I am start");
                strPosition = "I am in Box 3 Before";
                
                await next();
                strPosition = "I am in Box 3 After";
                //Console.WriteLine("I am End");
            });

            //app.Use(async (context, next) =>
            //{
            //    var userId = context.Session.GetString("userName");
            //  var path=  context.Request.Path.ToString();



            //    if (string.IsNullOrEmpty(path) || "/".Equals(path) || "/Users/Login".Equals(path,StringComparison.OrdinalIgnoreCase))
            //    {
            //        await next();
            //    }
            //    else
            //    {

            //        if (userId == null)
            //        {
            //            context.Response.Redirect("/Users/Login");
            //        } else
            //        {
            //            await next();
            //        }
            //    }



            //});

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

            //app.Use(async (context, next) =>
            //{
            //    DateTime StartDate= DateTime.Now; ;
            //    await next();
            //    DateTime EndDate = DateTime.Now;

            //    var milli = (EndDate - StartDate).Milliseconds;
            //    context.Response.Headers.Add("TimeTakenValue", milli.ToString());

            //});
            //    app.Use(async (context, next) =>
            //{
            //    int i = 1;
            //    if (context.Request.Path.ToString().ToLower().Equals("/")
            //   )
            //    {

            //         context.Response.Redirect("/Users/Login");


            //    }
            //    else
            //    {
            //        await next();
            //    }

            //    i = i + 1;

            //});


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("I am From middle ware run");

            //});
            app.UseAuthentication();
           
            app.UseRouting();
            app.UseAuthorization();

            //app.UseMvc((x) =>
            //{
            //    x.F
            //})
            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapControllerRoute(
                //  name: "default",
                //  pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
