using Autofac;
using MediatR.Bus.Autofac;
using Microsoft.EntityFrameworkCore;

namespace HumanResources
{
    public class HumanResourcesLibModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(EmployeeCreateHandler).Assembly);
            builder.RegisterAssemblyHandlers<EmployeeCreateHandler>();

            builder.Register(c => new DbContextOptionsBuilder<HumanResourcesContext>()
                    //.UseSqlServer(@"Data Source=IN01N01079\SQLEXPRESS;Initial Catalog=myTestDB;User Id=testuser; Password=sa;")
                    .UseSqlite(@"Data Source=..\~$BlazorCrud.HumanResources.sqlite")
                    .Options
                )
                .SingleInstance()
                .AsSelf();

            builder.Register(c => new HumanResourcesContext(c.Resolve<DbContextOptions<HumanResourcesContext>>()))
                .AsSelf();


            builder.RegisterBuildCallback(c =>
            {
                using (var scope = c.BeginLifetimeScope())
                {
                    var db = scope.Resolve<HumanResourcesContext>();
                    db.Database
                        .EnsureCreatedAsync(default)
                        .Wait();
                }
            });

            base.Load(builder);
        }
    }
}
