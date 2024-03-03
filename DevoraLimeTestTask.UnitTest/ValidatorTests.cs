using DevoraLimeTestTask.Business.Validators;
using DevoraLimeTestTask.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace DevoraLimeTestTask.UnitTest
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void HeroGeneratorValidatorTest_Should_Be_OK()
        {
            // Arrange
            string testString = "124";
            var validator = new HeroGeneratorValidator();

            // Act
            validator.Validate(testString);

            // Assert

            //Exception ex = Assert.ThrowsException<> .Catch(() => dokForrasBl.GetExpedialandoDokumentumForrasok());

            //    //vizsgálatok
            //    //volt hiba
            //    Assert.IsInstanceOf<Exception>(ex);
            //Assert.AreEqual(actual.Id, "SP100");
            //Assert.AreEqual(actual.PlatformCode, String.Empty);
        }

        [TestMethod]
        public void HeroGeneratorValidatorTest_With_Alphabet_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "X";
            var validator = new HeroGeneratorValidator();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => validator.Validate(testString));
        }

        [TestMethod]
        public void HeroGeneratorValidatorTest_Without_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "";
            var validator = new HeroGeneratorValidator();

            // Act & Assert
            Assert.ThrowsException<ValidationException>(() => validator.Validate(testString));
        }

        [TestMethod]
        public void HeroGeneratorValidatorTest_With_WhiteSpaces_Parameter_ShouldThrowException()
        {
            // Arrange
            string testString = "   ";
            var validator = new HeroGeneratorValidator();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => validator.Validate(testString));
        }
    }
}