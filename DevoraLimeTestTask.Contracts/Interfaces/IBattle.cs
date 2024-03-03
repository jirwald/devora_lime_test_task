using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IBattle
    {
        BattleHistory Execute(Guid arenaId, List<Fighter> fighters);
        void Defeat(Fighter fighter, FighterHistory fighterHistory);
        void Survive(Fighter fighter, FighterHistory fighterHistory);
        void Fight(int chance, FightingCouple couple, BattleHistoryEvent history);
    }
}
