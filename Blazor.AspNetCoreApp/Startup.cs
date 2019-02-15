﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Net.Mime;
using Autofac;
using Facilities;
using HumanResources;
using MediatR.Bus;
using MediatR.Bus.AspNetCore;
using MediatR.Bus.AspNetCore.Autofac;
using MediatR.Bus.Autofac;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Blazor
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddCors();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(typeof(HumanResourcesContext).Assembly)
            //    .AsImplementedInterfaces();

            //builder.RegisterType<HumanResourcesContext>()
            //    .AsSelf();
            //builder.RegisterType<FacilitiesContext>()
            //    .AsSelf();

            builder.RegisterModule<MediatorModule>();
            builder.RegisterModule<MediatorMiddlewareModule>();

            //builder.RegisterModule<HumanResourcesLibModule>();
            builder.RegisterMediatorWrappers<EmployeeCreateRequest>();

            //builder.RegisterModule<FacilitiesLibModule>();
            builder.RegisterMediatorWrappers<BuildingCreateRequest>();

            builder.RegisterMediatorRegistry<MediatorRegistry>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            app.UseResponseCompression();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            });


            app.UseMediatorMiddleware();
            app.UseBlazor<BlazorApp>();
        }
    }

}
