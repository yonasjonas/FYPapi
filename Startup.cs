﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using WebApi.Helpers;
using WebApi.Middleware;
using WebApi.Services;
using Stripe;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddMvc().AddNewtonsoftJson();
            services.AddDbContext<DataContext>();           
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c => { c.OperationFilter<SwaggerFileOperationFilter>();});
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBusinessServicesService, BusinessServicesService>();
            services.AddScoped<IProvidersService, ProvidersService>();
            services.AddScoped<IBusinesses, Businesses>();
            services.AddScoped<IWidgetsService, WidgetsService>();
            services.AddScoped<IBusinessManagers, BusinessManagers>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IBusinessInfo, BusinessInfo>();
            services.AddCors();
        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {

            //Stripe API key
            StripeConfiguration.ApiKey = "sk_test_lpWGLDj3KmD49Q1hWe3jr0HL";
            // migrate database changes on startup (includes initial db creation)
            // context.Database.Migrate();

            // generated swagger json and swagger ui middleware
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core Sign-up and Verification API"));


            app.UseRouting();


            //app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyHeader());
            // global cors policy
            app.UseCors(x => x.WithOrigins("http://localhost:3000")
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            app.UseStaticFiles();
            app.UseEndpoints(x => x.MapControllers());
        
       }
    }

    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = "multipart/form-data";
            if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
                return;

            var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
            operation.RequestBody.Content[fileUploadMime].Schema.Properties =
                fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
                {
                    Type = "file",
                    Format = "binary"
                });
            //operation.Consumes.Add("multipart/form-data");
        }
    }
}
