using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Contracts.Interfaces
{
    public interface IFighterFactory
    {
        Fighter CreateRandomFighter();
        IEnumerable<Fighter> CreateRandomFighters(int nr);
    }
}
