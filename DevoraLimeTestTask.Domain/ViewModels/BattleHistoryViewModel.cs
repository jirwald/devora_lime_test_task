using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Domain.ViewModels
{
    public class BattleHistoryViewModel
    {
        public int TurnsCount { get { return Duels.Count; } }
        public Duels Duels { get; set; } = new Duels();
    }
}
