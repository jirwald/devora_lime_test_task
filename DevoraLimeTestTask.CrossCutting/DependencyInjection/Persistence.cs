using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace DevoraLimeTestTask.CrossCutting.DependencyInjection
{
    public class Persistence : IWindsorInstaller
    {
        private const string PersistentAssemblyName = "DevoraLimeTestTask.Persistence";
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            InstallServices(container);
        }

        private static void InstallServices(IWindsorContainer container)
        {
            container.Register(Classes.FromAssemblyNamed(PersistentAssemblyName)
                                  .Where(type => type.IsClass && !type.IsAbstract && type.Name.Equals("PersistentDataService"))
                                  .WithServiceDefaultInterfaces()
                                  .LifestyleSingleton());
        }
    }
}
