using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Business.Factories
{
    public class FighterFactory : IFighterFactory
    {
        private readonly Random _random = new Random();
        private readonly IAppSettings? _appSettings;

        public FighterFactory(IAppSettings? appSettings) 
        {
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public Fighter CreateRandomFighter()
        {
            int FighterType = _random.Next(3);

            switch (FighterType)
            {
                case 0:
                    return new Swordsman { AttackChance = _appSettings!.BattleDomainModel!.Swordsman };
                case 1:
                    return new Archer { AttackChance = _appSettings!.BattleDomainModel!.Archer };
                case 2:
                    return new Knight { AttackChance = _appSettings!.BattleDomainModel!.Knight };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerable<Fighter> CreateRandomFighters(int nr)
        {
            List<Fighter> fighters = new();
            for (int i = 0; i < nr; i++)
            {
                Fighter fighter = CreateRandomFighter();
                fighter.Id = i;
                fighters.Add(fighter);
            }

            return fighters;
        }
    }
}
