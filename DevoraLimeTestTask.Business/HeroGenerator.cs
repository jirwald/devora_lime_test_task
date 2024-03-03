using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;

namespace DevoraLimeTestTask.Business
{
    public class HeroGenerator : IHeroGenerator
    {
        private readonly IPersistentDataService _persistentDataService;
        private readonly IFighterFactory _fighterFactory;

        public HeroGenerator(IPersistentDataService persistentDataService, IFighterFactory fighterFactory)
        {
            _persistentDataService = persistentDataService ?? throw new ArgumentNullException(nameof(persistentDataService));
            _fighterFactory = fighterFactory ?? throw new ArgumentNullException(nameof(fighterFactory));
        }

        public HeroGeneratorResult Execute(int heroesCount)
        {
            Guid arenaId = Guid.NewGuid();

            List<Fighter> fighters = _fighterFactory.CreateRandomFighters(heroesCount).ToList();

            _persistentDataService.CreateArena(arenaId, fighters);

            return new HeroGeneratorResult { ArenaId = arenaId };
        }
    }
}
