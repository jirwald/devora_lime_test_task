namespace DevoraLimeTestTask.Domain.Models
{
    public class BattleDomainModel
    {
        public int HPIncreasePerTurn { get; set; }
        public FighterDomainModel Archer { get; set; } = new FighterDomainModel();
        public FighterDomainModel Swordsman { get; set; } = new FighterDomainModel();
        public FighterDomainModel Knight { get; set; } = new FighterDomainModel();
    }
}
