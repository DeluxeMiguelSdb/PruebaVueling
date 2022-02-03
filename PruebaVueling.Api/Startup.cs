using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaVueling.Core.Interfaces;
using PruebaVueling.Core.Logic;
using PruebaVueling.Core.Services;
using PruebaVueling.Infrastructure.Data;
using PruebaVueling.Infrastructure.Interfaces;
using PruebaVueling.Infrastructure.Mappings;
using PruebaVueling.Infrastructure.Repositories;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace PruebaVueling.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            //dependencies
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IRateRepository, RateRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<ITransactionLogic, TransactionLogic>();
            services.AddTransient<ITransactionMapper, TransactionMapper>();
            services.AddTransient<IExceptionlogRepository, ExceptionlogRepository>();

            //BBDD Connection
            services.AddDbContext<PruebaVuelingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PruebaVueling")));

            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Prueba Vueling" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba Vueling");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
