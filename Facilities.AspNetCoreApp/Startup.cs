﻿using System.Linq;
using System.Net.Mime;
using Autofac;
using MediatR.ConnectR;
using MediatR.ConnectR.AspNetCore;
using MediatR.ConnectR.AspNetCore.Autofac;
using MediatR.ConnectR.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace Facilities
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                });
            });

            services.AddCors();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(FacilitiesContext).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterType<FacilitiesContext>()
                .AsSelf();

            builder.RegisterModule<MediatorModule>();
            builder.RegisterModule<MediatorMiddlewareModule>();

            builder.RegisterModule<FacilitiesLibModule>();
            builder.RegisterMediatorRequestWrappers<BuildingCreateRequest>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            app.UseResponseCompression();

            app.UseMediatorMiddleware();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
