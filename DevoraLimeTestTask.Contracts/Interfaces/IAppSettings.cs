using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IAppSettings
    {
        BattleDomainModel? BattleDomainModel { get; }
        HeroGeneratorDomainModel? HeroGeneratorDomainModel { get; }
    }
}
