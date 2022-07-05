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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApiPractise
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
            services.AddControllers();  //.AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, z =>
            {
                z.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("012345678901234567")),
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false
                };
            });

            services.AddCors(x =>
            {
                x.AddPolicy("local",
                    y =>
                    {
                        y.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        ;
                    }
                    );
            });


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

            //builder.Services.AddAuthentication("cookies").AddCookie("cookies", (x) =>
            //{
            //    x.LoginPath = "/Login/Index";
            //    x.LogoutPath = "/Login/Logout";
            //    x.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            //    x.AccessDeniedPath = "/home/UnAuth";
            //    x.SlidingExpiration = true;

            //});

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.Use(async (context, next) =>
            {
               await next();
            });
                app.UseRouting();
            app.UseAuthorization();
               app.UseCors("local");

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}
