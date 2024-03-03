using DevoraLimeTestTask.Contracts.DTO;
using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IBattleMapper
    {
        BattlesResultDTO Map(BattleHistory history);
    }
}
