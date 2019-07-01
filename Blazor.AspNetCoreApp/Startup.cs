using Autofac;
using Blazor.BrowserApp;
using HumanResources;
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

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder
            //        .AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials()
            //        );
            //});
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
            
            app.UseResponseCompression();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            //});

            app.UseClientSideBlazorFiles<ClientStartup>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<ClientStartup>("index.html");
            });

            app.UseMediatorMiddleware();

            //app.UseBlazorDebugging();
        }
    }
}
