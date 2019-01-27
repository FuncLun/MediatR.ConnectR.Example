using Autofac;
using MediatR.Bus.Autofac;

namespace HumanResources
{
    public class HumanResourcesLibModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(EmployeeCreateHandler).Assembly);
            builder.RegisterAssemblyHandlers<EmployeeCreateHandler>();

            base.Load(builder);
        }
    }
}
