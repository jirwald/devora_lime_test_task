using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IPersistentDataService
    {
        int ArenaCount { get; }
        void CreateArena(Guid arenaId, List<Fighter> fighters);
        List<Fighter> GetFightersByArena(Guid id);
    }
}
