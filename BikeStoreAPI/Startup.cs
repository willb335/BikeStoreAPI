using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStoreAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.OpenApi.Models;
using MicroElements.Swashbuckle.FluentValidation;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;

namespace BikeStoreAPI
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
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BikeStoreAPI", Version = "v1" });
                options.AddFluentValidationRules();
            });
            services.AddDbContext<BikeStoresContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("BookStores")));
            services.AddControllers().AddFluentValidation(c =>
            {
                c.RegisterValidatorsFromAssemblyContaining<Startup>();
                // Optionally set validator factory if you have problems with scope resolve inside validators.
                c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
            }).AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddLogging(builder => builder.AddConsole());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

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
