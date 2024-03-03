namespace DevoraLimeTestTask.Domain.Models
{
    public class BattleHistoryEvent
    {
        public BattleHistoryEvent(FightingCouple couple, int turnNr)
        {
            TurnNr = turnNr;
            Attacker = new()
            {
                Id = couple.Attacker.Id,
                Entity = couple.Attacker.GetType().Name,
                InitialHP = couple.Attacker.HP
            };
            Defenser = new()
            {
                Id = couple.Defenser.Id,
                Entity = couple.Defenser.GetType().Name,
                InitialHP = couple.Defenser.HP
            };
        }

        public int TurnNr { get; set; }
        public FighterHistory Attacker { get; set; }
        public FighterHistory Defenser { get; set; }
    }
}
