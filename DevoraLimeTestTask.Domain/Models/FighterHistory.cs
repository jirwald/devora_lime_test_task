namespace DevoraLimeTestTask.Domain.Models
{
    public class FighterHistory
    {
        public int Id{ get; set; }
        public string Entity { get; set; } = string.Empty; 
        public int InitialHP { get; set; }
        public int FinishingHP { get; set; }
    }
}
