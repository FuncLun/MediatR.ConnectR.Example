using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Facilities;
using HumanResources;
using MediatR.ConnectR.Autofac;
using MediatR.ConnectR.BlazorHttpClient;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.BrowserApp
{
    public class ClientStartup
    {
        public static IContainer ApplicationContainer { get; private set; }
        //public static BrowserServiceProvider BrowserServiceProvider { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
        }


        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ClientStartup).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterModule<MediatorModule>();

            builder.RegisterClientRequestHandlers<EmployeeGetRequest>(
                    typeof(HttpClientHandler<,>)
                )
                .WithParameters(
                    new TypedParameter(typeof(Uri), new Uri("http://localhost:49224"))
                );

            builder.RegisterClientRequestHandlers<BuildingGetRequest>(
                    typeof(HttpClientHandler<,>)
                )
                .WithParameters(
                    new TypedParameter(typeof(Uri), new Uri("http://localhost:64831"))
                );
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            var builder = new ContainerBuilder();

            app.AddComponent<App>("app");

            //BrowserServiceProvider = new BrowserServiceProvider(services =>
            //{
            //    builder.Populate(services);
            //});

            ApplicationContainer = builder.Build();

            var asp = new AutofacServiceProvider(ApplicationContainer);
            
            //app.AddComponent<BlazorCrudComponent>();
            //new BrowserRenderer(asp).AddComponent<BrowserApp.BlazorCrudComponent>("app");
        }
    }
}
