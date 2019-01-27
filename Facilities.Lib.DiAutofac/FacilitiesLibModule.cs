using Autofac;
using MediatR.Bus.Autofac;

namespace Facilities
{
    public class FacilitiesLibModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BuildingCreateHandler).Assembly);
            builder.RegisterAssemblyHandlers<BuildingCreateHandler>();

            base.Load(builder);
        }
    }
}
