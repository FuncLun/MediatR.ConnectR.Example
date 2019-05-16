// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Autofac;
using Blazor.BrowserApp;
using Facilities;
using HumanResources;
using MediatR.ConnectR;
using MediatR.ConnectR.AspNetCore;
using MediatR.ConnectR.AspNetCore.Autofac;
using MediatR.ConnectR.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Blazor
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddResponseCompression(options =>
            {
                //options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                //{
                //    MediaTypeNames.Application.Octet,
                //    WasmMediaTypeNames.Application.Wasm,
                //});
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
            //builder.RegisterMediatorRequestWrappers<EmployeeCreateHandler>();

            //builder.RegisterModule<FacilitiesLibModule>();
            //builder.RegisterMediatorRequestWrappers<BuildingCreateHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(options =>
            //{
            //    options.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials();
            //});

            app.UseResponseCompression();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            //});


            app.UseMediatorMiddleware();
            app.UseBlazor<ClientStartup>();

            app.UseBlazorDebugging();
        }
    }

}
