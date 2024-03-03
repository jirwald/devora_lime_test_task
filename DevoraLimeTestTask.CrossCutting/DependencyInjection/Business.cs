using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor.MsDependencyInjection;
using Castle.Windsor;
using DevoraLimeTestTask.Business.Settings;
using DevoraLimeTestTask.Contracts.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DevoraLimeTestTask.CrossCutting.DependencyInjection
{
    public class Business : IWindsorInstaller
    {
        private const string BusinessAssemblyName = "DevoraLimeTestTask.Business";
        private readonly IAppSettings _applicationSettings;

        public Business(IConfiguration configuration)
        {
            _applicationSettings = new AppSettings(configuration);
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterApplicationSettings(container, _applicationSettings);
            InstallServices(container);
        }

        void RegisterApplicationSettings(IWindsorContainer container, IAppSettings applicationSettings)
        {
            container.Register(Castle.MicroKernel.Registration.Component.For<IAppSettings>().Instance(applicationSettings).LifestyleSingleton());
        }

        private static void InstallServices(IWindsorContainer container)
        {
            container.Register(Classes.FromAssemblyNamed(BusinessAssemblyName)
                                  .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Command"))
                                  .WithServiceDefaultInterfaces()
                                  .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Classes.FromAssemblyNamed(BusinessAssemblyName)
                                  .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Validator"))
                                  .WithServiceDefaultInterfaces()
                                  .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Classes.FromAssemblyNamed(BusinessAssemblyName)
                                  .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Mapper"))
                                  .WithServiceDefaultInterfaces()
                                  .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Classes.FromAssemblyNamed(BusinessAssemblyName)
                                  .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Factory"))
                                  .WithServiceDefaultInterfaces()
                                  .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Classes.FromAssemblyNamed(BusinessAssemblyName)
                                  .Where(type => type.IsClass && !type.IsAbstract && type.Name.Equals("Battle"))
                                  .WithServiceDefaultInterfaces()
                                  .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Classes.FromAssemblyNamed(BusinessAssemblyName)
                                  .Where(type => type.IsClass && !type.IsAbstract && type.Name.Equals("HeroGenerator"))
                                  .WithServiceDefaultInterfaces()
                                  .LifestyleCustom<MsScopedLifestyleManager>());
        }
    }
}