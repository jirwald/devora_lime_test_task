namespace DevoraLimeTestTask.Contracts.DTOs
{
    public class FighterHistoryDTO
    {
        public int Id { get; set; }
        public string Entity { get; set; } = string.Empty;
        public int InitialHP { get; set; }
        public int FinishingHP { get; set; }
    }
}
