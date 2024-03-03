using DevoraLimeTestTask.Contracts.DTOs;
using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IHeroGeneratorMapper
    {
        HeroGeneratorResultDTO Map(HeroGeneratorResult id);
    }
}
