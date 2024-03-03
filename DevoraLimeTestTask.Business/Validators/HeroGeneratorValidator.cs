using DevoraLimeTestTask.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;

// Éles feladat esetén absztrakt, egységes validátor minta lenne kívánatos

namespace DevoraLimeTestTask.Business.Validators
{
    public class HeroGeneratorValidator : IHeroGeneratorValidator
    {
        public void Validate(string model)
        {
            if (String.IsNullOrEmpty(model)) throw new ValidationException("Empty Fighter number.");
            if (!Int32.TryParse(model, out int _)) throw new ArgumentException();
        }
    }
}
