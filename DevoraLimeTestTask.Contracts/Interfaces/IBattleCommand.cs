using DevoraLimeTestTask.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IBattleCommand
    {
        ActionResult<BattlesResultDTO> Execute(string arenaId);
    }
}
