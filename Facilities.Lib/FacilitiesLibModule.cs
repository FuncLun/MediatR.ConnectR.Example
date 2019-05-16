using Autofac;
//using MediatR.ConnectR.Autofac;
using Microsoft.EntityFrameworkCore;

namespace Facilities
{
    public class FacilitiesLibModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BuildingCreateHandler).Assembly)
                .AsImplementedInterfaces();
            //builder.RegisterAssemblyMediatorHandlers<BuildingCreateHandler>();

            builder.Register(c => new DbContextOptionsBuilder<FacilitiesContext>()
                    .UseSqlite(@"Data Source=..\~$ExampleCrud.Facilities.sqlite")
                    .Options
                )
                .SingleInstance()
                .AsSelf();

            builder.Register(c => new FacilitiesContext(c.Resolve<DbContextOptions<FacilitiesContext>>()))
                .AsSelf();

            builder.RegisterBuildCallback(c =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    var db = scope.Resolve<FacilitiesContext>();
                    db.Database
                        .EnsureCreatedAsync(default)
                        .Wait();
                }
            });

            base.Load(builder);
        }
    }
}
