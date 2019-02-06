using Autofac;
using MediatR.Bus.AspNetCore;
using MediatR.Bus.AspNetCore.Autofac;
using MediatR.Bus.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(HumanResourcesContext).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterType<HumanResourcesContext>()
                .AsSelf();

            builder.RegisterModule<MediatorModule>();
            builder.RegisterModule<MediatorMiddlewareModule>();

            builder.RegisterModule<HumanResourcesLibModule>();
            builder.RegisterMediatorMessageDelegates<EmployeeCreateRequest>();

            builder.RegisterMediatorRegistry<MediatorRegistry>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
