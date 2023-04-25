using Autofac;
using WebAppObligAtions.Interface;
using WebAppObligAtions.Repositories;

namespace WebAppObligAtions.DependencyInjection
{
    public class DependencyRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicesAPIRepositorie>().As<IServicesAPI>();
        }
    }
}
