using DevoraLimeTestTask.Business.Validators;
using System.ComponentModel.DataAnnotations;

namespace DevoraLimeTestTask.UnitTests
{
    public class ValidatorTests
    {
        private HeroGeneratorValidator hValidator = new HeroGeneratorValidator();
        private BattleValidator bValidator = new BattleValidator();

        [Test]
        public void HeroGeneratorValidatorTest_Should_Be_OK()
        {
            // Arrange
            string testString = "124";

            // Act & Assert
            Assert.DoesNotThrow(() =>
            {
                hValidator.Validate(testString);
            });
        }

        [Test]
        public void HeroGeneratorValidatorTest_With_Alphabet_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "X";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => hValidator.Validate(testString));
        }

        [Test]
        public void HeroGeneratorValidatorTest_Without_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "";

            // Act & Assert
            Assert.Throws<ValidationException>(() => hValidator.Validate(testString));
        }

        [Test]
        public void HeroGeneratorValidatorTest_With_WhiteSpaces_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "   ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => hValidator.Validate(testString));
        }

        [Test]
        public void BattleValidatorTest_Should_Be_OK()
        {
            // Arrange
            string testString = "2f47499a-d6b9-4d8a-b1e0-d1e8ec2675b1";


            // Act & Assert
            Assert.DoesNotThrow(() =>
            {
                bValidator.Validate(testString);
            });
        }

        [Test]
        public void BattleValidatorTest_With_WrongGuid_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "2f47499a-d6b9-4d8a-1e0-d1e8ec2675b1";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => bValidator.Validate(testString));
        }

        [Test]
        public void BattleValidatorTest_With_Alphabet_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "X";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => bValidator.Validate(testString));
        }

        [Test]
        public void BattleValidatorTest_Without_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "";

            // Act & Assert
            Assert.Throws<ValidationException>(() => bValidator.Validate(testString));
        }

        [Test]
        public void BattleValidatorTest_With_WhiteSpaces_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "   ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => bValidator.Validate(testString));
        }
    }
}
