using DevoraLimeTestTask.Contracts.DTO;
using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevoraLimeTestTask.Business.Commands
{
    public class BattleCommand : IBattleCommand
    {
        private readonly IBattle _battle;
        private readonly IAppSettings? _appSettings;
        private readonly IPersistentDataService _persistentDataService;
        private readonly IBattleValidator _battleValidator;
        private readonly IBattleMapper _battleMapper;
        public BattleCommand(IBattle battle,
            IAppSettings? appSettings,
            IPersistentDataService persistentDataService,
            IBattleValidator battleValidator,
            IBattleMapper battleMapper) 
        {
            _battle = battle ?? throw new ArgumentNullException(nameof(battle));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _persistentDataService = persistentDataService ?? throw new ArgumentNullException(nameof(persistentDataService));
            _battleValidator = battleValidator ?? throw new ArgumentNullException(nameof(battleValidator));
            _battleMapper = battleMapper ?? throw new ArgumentNullException(nameof(battleMapper));
        }

        public ActionResult<BattlesResultDTO> Execute(string arenaId)
        {
            _battleValidator.Validate(arenaId);
            Guid arena = Guid.Parse(arenaId);

            List<Fighter> fighters = _persistentDataService.GetFightersByArena(arena);

            BattleHistory history = _battle.Execute(arena, fighters);

            return new OkObjectResult(_battleMapper.Map(history));
        }
    }
}
