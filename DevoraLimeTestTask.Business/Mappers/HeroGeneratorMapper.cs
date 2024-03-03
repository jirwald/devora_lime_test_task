using DevoraLimeTestTask.Contracts.DTOs;
using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;

// Éles feladat esetén absztrakt, egységes mapper minta lenne kívánatos
// Lehetne automapperrel is, de felesleges overheadje lenne jelen esetben

namespace DevoraLimeTestTask.Business.Mappers
{
    public class HeroGeneratorMapper : IHeroGeneratorMapper
    {
        public HeroGeneratorResultDTO Map(HeroGeneratorResult id)
        {
            return new HeroGeneratorResultDTO { ArenaId = id.ArenaId.ToString() };
        }
    }
}

