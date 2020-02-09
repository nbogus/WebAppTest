using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace WebApp.Data.IoC
{
    public class DataModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var suffixesToRegister = new[] { "Repository"};

            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => suffixesToRegister.Any(suffix => t.Name.EndsWith(suffix)))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<UsersDataContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
