using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Business
{
    public class Battle : IBattle
    {
        private IAppSettings _appSettings;
        private List<Fighter> _fighters = new();
        private readonly Random _random = new Random();

        public Battle(IAppSettings appSettings)
        {
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public BattleHistory Execute(Guid arenaId, List<Fighter> fighters)
        {
            _fighters = fighters;
            BattleHistory battleHistory = new();

            PrepareFighters();
            int turnNr = 0;

            while (FightersCount() > 1)
            {
                FightingCouple couple = RandomPairing();
                BattleHistoryEvent history = DoBattle(couple, turnNr);
                battleHistory.Add(history);
                VitalityIncrease(_fighters.Where(f => f.IsAlive && !f.Paired).ToList());
                turnNr++;
            }

            return battleHistory;
        }

        private void PrepareFighters()
        {
            _fighters.ForEach(f => { f.IsAlive = true; f.HP = f.AttackChance.DefaultHP; });
        }

        private int FightersCount()
        {
            return _fighters.Count(f => f.IsAlive);
        }

        private FightingCouple RandomPairing()
        {
            FightingCouple couple = new();

            _fighters.ForEach(f => { f.Paired = false; });

            List<Fighter> potentials = _fighters.Where(f => f.IsAlive && !f.Paired).ToList();
            int index = _random.Next(potentials.Count());
            couple.Attacker = potentials[index];
            couple.Attacker.Paired = true;

            potentials = _fighters.Where(f => f.IsAlive && !f.Paired).ToList();
            index = _random.Next(potentials.Count());
            couple.Defenser = potentials[index];
            couple.Defenser.Paired = true;

            return couple;
        }

        private BattleHistoryEvent DoBattle(FightingCouple couple, int turnNr)
        {
            BattleHistoryEvent history = new(couple, turnNr);

            switch (couple.Defenser.GetType().Name)
            {
                case "Archer":
                    Fight(couple.Attacker.AttackChance.ChanceToWinVsArcher, couple, history);
                    break;

                case "Knight":
                    Fight(couple.Attacker.AttackChance.ChanceToWinVsKnight, couple, history);
                    break;

                case "Swordsman":
                    Fight(couple.Attacker.AttackChance.ChanceToWinVsSwordsman, couple, history);
                    break;
            }

            return history;
        }

        public void Fight(int chance, FightingCouple couple, BattleHistoryEvent history)
        {
            if (chance == 0)
            {
                Survive(couple.Attacker, history.Attacker); 
                Survive(couple.Defenser, history.Defenser);
            }
            else if (chance == 100)
            {
                Defeat(couple.Defenser, history.Defenser);
                Survive(couple.Attacker, history.Attacker);
            }
            else if (chance == -100)
            {
                Defeat(couple.Attacker, history.Attacker);
                Survive(couple.Defenser, history.Defenser);
            } else
            {
                if(chance < _random.Next(100))
                {
                    Defeat(couple.Defenser, history.Defenser);
                    Survive(couple.Attacker, history.Attacker);
                } else
                {
                    Survive(couple.Attacker, history.Attacker);
                    Survive(couple.Defenser, history.Defenser);
                }
            }
        }

        public void Defeat(Fighter fighter, FighterHistory fighterHistory)
        {
            fighter.IsAlive = false;
            fighter.HP = 0;
            fighterHistory.FinishingHP = 0;
        }

        public void Survive(Fighter fighter, FighterHistory fighterHistory)
        {
            if (fighter.HP < fighter.AttackChance.DefaultHP / 2)
            {
                fighter.IsAlive = false;
                fighter.HP = 0;
                fighterHistory.FinishingHP = 0;
            } else
            {
                fighter.HP = fighter.HP / 2;
                fighterHistory.FinishingHP = fighter.HP;
            }
        }

        private void VitalityIncrease(List<Fighter> fighters)
        {
            fighters.ForEach(fighter => fighter.IncreaseHP(_appSettings.BattleDomainModel!.HPIncreasePerTurn));
        }
    }
}
