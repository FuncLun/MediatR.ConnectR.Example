using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Blazor.Hosting;

namespace Blazor.BrowserApp
{
    public class ClientProgram
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                //.ConfigureServices(services => services.AddAutofac())
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(ClientStartup.ConfigureContainer))
                .UseBlazorStartup<ClientStartup>();
    }
}
