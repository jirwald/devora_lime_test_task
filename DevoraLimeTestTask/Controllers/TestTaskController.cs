
using DevoraLimeTestTask.Contracts.DTO;
using DevoraLimeTestTask.Contracts.DTOs;
using DevoraLimeTestTask.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevoraLimeTestTask.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class TestTaskController : ControllerBase
    {
        private readonly IBattleCommand _battleCommand;
        private readonly IHeroGeneratorCommand _heroGeneratorCommand;

        public TestTaskController(IBattleCommand battleCommand,
            IHeroGeneratorCommand heroGeneratorCommand)
        {
            _battleCommand = battleCommand;
            _heroGeneratorCommand = heroGeneratorCommand;
        }

        [HttpPost]
        public ActionResult<HeroGeneratorResultDTO> GenerateHeroes(string heroesCount)
        {
            ActionResult<HeroGeneratorResultDTO> result = new NoContentResult();
            try
            {
                return _heroGeneratorCommand.Execute(heroesCount);
            }
            // Hiba esetén naplózni és a policynak megfelelõ eredményt visszaadni
            catch (ArgumentNullException ex)
            {
                result = new BadRequestResult();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                result = new NoContentResult();
            }
            catch (Exception ex)
            {
                result = new NotFoundResult();
            }

            return result;
        }

        [HttpPost]
        public ActionResult<BattlesResultDTO> DoBattles(string arenaId)
        {
            ActionResult<BattlesResultDTO> result = new NoContentResult();
            try
            {
                return _battleCommand.Execute(arenaId);
            }
            // Hiba esetén naplózni és a policynak megfelelõ eredményt visszaadni
            catch (ArgumentNullException ex)
            {
                result = new BadRequestResult();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                result = new NoContentResult();
            }
            catch (Exception ex)
            {
                result = new NotFoundResult();
            }

            return result;
        }
    }
}
