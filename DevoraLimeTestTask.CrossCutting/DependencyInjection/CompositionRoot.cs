using Castle.Windsor;
using Microsoft.Extensions.DependencyInjection;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DevoraLimeTestTask.CrossCutting.DependencyInjection
{
    public class CompositionRoot : IServiceProviderFactory<IWindsorContainer>
    {
        private readonly IConfiguration _configuration;

        protected IServiceCollection ServiceCollection { get; private set; } = null!;

        public CompositionRoot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IWindsorContainer CreateBuilder(IServiceCollection services)
        {
            ServiceCollection = services;
            return new WindsorContainer();
        }

        public IServiceProvider CreateServiceProvider(IWindsorContainer containerBuilder)
        {
            containerBuilder.Install(
                new Business(_configuration),
                new Persistence()
            );

            return WindsorRegistrationHelper.CreateServiceProvider(containerBuilder, ServiceCollection);
        }
    }
}
