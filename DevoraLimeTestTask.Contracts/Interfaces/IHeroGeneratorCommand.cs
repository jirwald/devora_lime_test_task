using DevoraLimeTestTask.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IHeroGeneratorCommand
    {
        ActionResult<HeroGeneratorResultDTO> Execute(string heroesCount);
    }
}
