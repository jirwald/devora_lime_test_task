using DevoraLimeTestTask.Contracts.DTO;
using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;

// Itt lehet meghatározni a csata végén visszaadott history adatokat
// Lehetne automapperrel is, de felesleges overheadje lenne jelen esetben
// Éles feladat esetén absztrakt, egységes mapper minta lenne kívánatos

namespace DevoraLimeTestTask.Business.Mappers
{
    public class BattleMapper : IBattleMapper
    {
        public BattlesResultDTO Map(BattleHistory history)
        {
            BattlesResultDTO result = new();
            result.Duels = new();
            foreach (var item in history)
            {
                result.Duels.Add(new()
                {
                    TurnNr = item.TurnNr,
                    Attacker = new()
                    {
                        Entity = item.Attacker.Entity,
                        Id = item.Attacker.Id,
                        InitialHP = item.Attacker.InitialHP,
                        FinishingHP = item.Attacker.FinishingHP
                    },
                    Defenser = new()
                    {
                        Entity = item.Defenser.Entity,
                        Id = item.Defenser.Id,
                        InitialHP = item.Defenser.InitialHP,
                        FinishingHP = item.Defenser.FinishingHP
                    }
                });
            }
            return result;
        }
    }
}
