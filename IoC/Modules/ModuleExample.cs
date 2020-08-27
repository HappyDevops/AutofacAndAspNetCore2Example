using Autofac;
using HappyDevops.AutofacAndAspnetCore2.Dependences;

namespace HappyDevops.AutofacAndAspnetCore2.IoC.Modules
{
    public class ModuleExample : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new GenericComponent())
                .As<IGenericInterface>()
                .AsSelf()
                .InstancePerDependency();

        }
    }
}
