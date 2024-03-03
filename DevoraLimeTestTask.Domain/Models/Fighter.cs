namespace DevoraLimeTestTask.Domain.Models
{
    public class Fighter
    {
        public int Id { get; set; }
        public bool IsAlive { get; set; } = true;
        public int HP { get; set; }
        public bool Paired { get; set; }
        public FighterDomainModel AttackChance { get; set; } = new();

        public void IncreaseHP(int increase)
        {
            HP += increase;
            if (HP > AttackChance.DefaultHP) HP = AttackChance.DefaultHP;
        }
    }
}
