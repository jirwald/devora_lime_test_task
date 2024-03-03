using DevoraLimeTestTask.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;

// Éles feladat esetén absztrakt, egységes validátor minta lenne kívánatos

namespace DevoraLimeTestTask.Business.Validators
{
    public class BattleValidator : IBattleValidator
    {
        public void Validate(string model)
        {
            if (String.IsNullOrEmpty(model)) throw new ValidationException("Empty Arena id.");
            if (!Guid.TryParse(model, out Guid _)) throw new ArgumentException("Wrong guid form.");
        }
    }
}
