using System;
using System.Net.Http;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Facilities;
using HumanResources;
using MediatR.Bus.Autofac;
using MediatR.Bus.BlazorHttpClient;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;

namespace Blazor
{
    public class BlazorApp
    {
        private BlazorApp()
        { }

        public static IContainer ApplicationContainer { get; private set; }
        public static BrowserServiceProvider BrowserServiceProvider { get; private set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(BlazorApp).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterModule<MediatorModule>();

            builder.RegisterClientHandlers<EmployeeGetRequest>(
                typeof(HttpClientHandler<,>)
                )
                .WithParameters(
                    new TypedParameter(typeof(Uri), new Uri("http://localhost:49224"))
                    );

            builder.RegisterClientHandlers<BuildingGetRequest>(
                typeof(HttpClientHandler<,>)
                )
                .WithParameters(
                    new TypedParameter(typeof(Uri), new Uri("http://localhost:64831"))
                );

            BrowserServiceProvider = new BrowserServiceProvider(services =>
            {
                builder.Populate(services);
            });

            ApplicationContainer = builder.Build();

            var asp = new AutofacServiceProvider(ApplicationContainer);

            new BrowserRenderer(asp).AddComponent<BrowserApp.BlazorCrudComponent>("app");
        }
    }
}
