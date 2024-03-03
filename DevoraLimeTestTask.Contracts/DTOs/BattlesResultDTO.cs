namespace DevoraLimeTestTask.Contracts.DTO
{
    public class BattlesResultDTO
    {
        public int TurnsCount { get { return Duels.Count; } }
        public DuelsDTO Duels { get; set; } = new DuelsDTO();
    }
}
