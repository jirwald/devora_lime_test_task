using DevoraLimeTestTask.Business;
using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevoraLimeTestTask.UnitTests
{
    public class DomainTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VitalityIncreaseTest_With_High_HP_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { HP = 100, AttackChance = new FighterDomainModel() { DefaultHP = 100 } };

            // Act
            fighter.IncreaseHP(10);

            // Assert
            Assert.That(fighter.HP, Is.EqualTo(100));
        }

        [Test]
        public void VitalityIncreaseTest_With_Low_HP_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { HP = 50, AttackChance = new FighterDomainModel() { DefaultHP = 100 } };

            // Act
            fighter.IncreaseHP(10);

            // Assert
            Assert.That(fighter.HP, Is.EqualTo(60));
        }
    }
}

