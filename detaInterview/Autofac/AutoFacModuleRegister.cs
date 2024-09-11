using Autofac;
namespace detaInterview.Autofac
{
    public class AutoFacModuleRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(o => o.Name.EndsWith("Service")).AsImplementedInterfaces().SingleInstance();
        }
    }
}
