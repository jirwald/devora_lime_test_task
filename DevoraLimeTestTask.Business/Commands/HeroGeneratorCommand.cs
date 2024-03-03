using DevoraLimeTestTask.Contracts.DTOs;
using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevoraLimeTestTask.Business.Commands
{
    public class HeroGeneratorCommand : IHeroGeneratorCommand
    {
        private readonly IHeroGenerator _heroGenerator;
        private readonly IAppSettings? _appSettings;
        private readonly IPersistentDataService _persistentDataService;
        private readonly IHeroGeneratorValidator _heroGeneratorValidator;
        private readonly IHeroGeneratorMapper _heroGeneratorMapper;

        public HeroGeneratorCommand(IHeroGenerator heroGenerator,
            IAppSettings? appSettings,
            IPersistentDataService persistentDataService,
            IHeroGeneratorValidator heroGeneratorValidator,
            IHeroGeneratorMapper heroGeneratorMapper)
        {
            _heroGenerator = heroGenerator ?? throw new ArgumentNullException(nameof(heroGenerator));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _persistentDataService = persistentDataService ?? throw new ArgumentNullException(nameof(persistentDataService));
            _heroGeneratorValidator = heroGeneratorValidator ?? throw new ArgumentNullException(nameof(heroGeneratorValidator));
            _heroGeneratorMapper = heroGeneratorMapper ?? throw new ArgumentNullException(nameof(heroGeneratorMapper));
        }

        public ActionResult<HeroGeneratorResultDTO> Execute(string heroesCount)
        {
            _heroGeneratorValidator.Validate(heroesCount);
            int heroesNr = Int32.Parse(heroesCount);

            if (_persistentDataService.ArenaCount >= _appSettings!.HeroGeneratorDomainModel!.MaxNumberOfArenas) throw new ArgumentOutOfRangeException("Maximum arena number reached.");
            if (_appSettings.HeroGeneratorDomainModel.MinNumberOfFighters > heroesNr) throw new ArgumentOutOfRangeException("Too few fighters.");
            if (_appSettings.HeroGeneratorDomainModel.MaxNumberOfFighters < heroesNr) throw new ArgumentOutOfRangeException("Too many fighters.");

            HeroGeneratorResult id = _heroGenerator.Execute(heroesNr);

            return _heroGeneratorMapper.Map(id);
        }
    }
}
