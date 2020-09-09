using System;
using Elmah.Io.AspNetCore;
using LeleStore.Domain.StoreContext.Handlers;
using LeleStore.Domain.StoreContext.Repositories;
using LeleStore.Domain.StoreContext.Services;
using LeleStore.Infra.Repositories;
using LeleStore.Infra.StoreContext.DataContexts;
using LeleStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.IO;
using LeleStore.Shared;

namespace LeleStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddResponseCompression();

            services.AddScoped<LeleDataContext, LeleDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LeleStore", Version = "v1" });
            });

            services.AddElmahIo(o =>
            {
                o.ApiKey = "apikey";
                o.LogId = new Guid("logId");
            });

            Settings.ConnectionString = $"{Configuration["ConnectionString"]}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lele Store V1");
            });

            app.UseElmahIo();
        }
    }
}
