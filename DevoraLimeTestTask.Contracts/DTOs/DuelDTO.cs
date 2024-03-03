using DevoraLimeTestTask.Contracts.DTOs;

namespace DevoraLimeTestTask.Contracts.DTO
{
    public class DuelDTO
    {
        public int TurnNr { get; set; }
        public FighterHistoryDTO Attacker { get; set; }
        public FighterHistoryDTO Defenser { get; set; }

    }
}
