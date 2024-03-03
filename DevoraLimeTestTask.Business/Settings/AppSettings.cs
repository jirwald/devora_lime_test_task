using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace DevoraLimeTestTask.Business.Settings
{
    public class AppSettings : IAppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            BattleDomainModel = configuration.GetSection("BattleConfig").Get<BattleDomainModel>();
            HeroGeneratorDomainModel = configuration.GetSection("HeroGeneratorConfig").Get<HeroGeneratorDomainModel>();
        }

        public BattleDomainModel? BattleDomainModel { get; private set; }
        public HeroGeneratorDomainModel? HeroGeneratorDomainModel { get; private set; }
    }
}
