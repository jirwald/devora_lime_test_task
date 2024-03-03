using DevoraLimeTestTask.Business;
using DevoraLimeTestTask.Business.Validators;
using DevoraLimeTestTask.Contracts.Interfaces;
using DevoraLimeTestTask.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace DevoraLimeTestTask.UnitTests
{
    public class BusinessLogicTests
    {
        private Mock<IAppSettings> appSettingsMock;
        private Battle battle;

        [SetUp]
        public void Setup()
        {
            appSettingsMock = new Mock<IAppSettings>(MockBehavior.Loose);
            battle = new Battle(appSettingsMock.Object);
        }

        [Test]
        public void DefeatTest_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { IsAlive = true, HP = 10 };
            FighterHistory fighterHistory = new() { FinishingHP = 10 };

            // Act
            battle.Defeat(fighter, fighterHistory);

            // Assert
            Assert.That(fighter.HP, Is.EqualTo(0));
            Assert.That(fighter.IsAlive, Is.EqualTo(false));
            Assert.That(fighterHistory.FinishingHP, Is.EqualTo(0));
        }

        [Test]
        public void SurviveTest_With_High_HP_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { IsAlive = true, HP = 100, AttackChance = new FighterDomainModel() { DefaultHP = 100 } };
            FighterHistory fighterHistory = new() { FinishingHP = 0 };

            // Act
            battle.Survive(fighter, fighterHistory);

            // Assert
            Assert.That(fighter.HP, Is.EqualTo(50));
            Assert.That(fighter.IsAlive, Is.EqualTo(true));
            Assert.That(fighterHistory.FinishingHP, Is.EqualTo(50));
        }

        [Test]
        public void SurviveTest_With_Low_HP_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { IsAlive = true, HP = 20, AttackChance = new FighterDomainModel() { DefaultHP = 100 } };
            FighterHistory fighterHistory = new() { FinishingHP = 10 };

            // Act
            battle.Survive(fighter, fighterHistory);

            // Assert
            Assert.That(fighter.HP, Is.EqualTo(0));
            Assert.That(fighter.IsAlive, Is.EqualTo(false));
            Assert.That(fighterHistory.FinishingHP, Is.EqualTo(0));
        }

        [Test]
        public void FightTest_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { IsAlive = true, HP = 20, AttackChance = new FighterDomainModel() { DefaultHP = 100 } };
            Fighter attacker = new Knight()
            { 
                Id = 1,
                IsAlive = true,
                HP = 100,
                Paired = true
            };
            Fighter defenser = new Archer()
            {
                Id = 2,
                IsAlive = true,
                HP = 100,
                Paired = true
            };

            FightingCouple couple = new() { Attacker = attacker, Defenser = defenser };

            BattleHistoryEvent history = new(couple, 1);

            // Act
            battle.Fight(100, couple, history);

            // Assert
            Assert.That(defenser.HP, Is.EqualTo(0));
            Assert.That(attacker.HP, Is.EqualTo(50));
            Assert.That(attacker.IsAlive, Is.EqualTo(true));
            Assert.That(defenser.IsAlive, Is.EqualTo(false));
            Assert.That(history.Attacker.FinishingHP, Is.EqualTo(50));
            Assert.That(history.Defenser.FinishingHP, Is.EqualTo(0));
        }

        [Test]
        public void FightTest_With_Low_HP_Should_Be_OK()
        {
            // Arrange
            Fighter attacker = new Knight()
            {
                Id = 1,
                IsAlive = true,
                HP = 30,
                Paired = true,
                AttackChance = new FighterDomainModel() { DefaultHP = 80 }
            };
            Fighter defenser = new Archer()
            {
                Id = 2,
                IsAlive = true,
                HP = 100,
                Paired = true,
                AttackChance = new FighterDomainModel() { DefaultHP = 100 }
            };

            FightingCouple couple = new() { Attacker = attacker, Defenser = defenser };

            BattleHistoryEvent history = new(couple, 1);

            // Act
            battle.Fight(100, couple, history);

            // Assert
            Assert.That(defenser.HP, Is.EqualTo(0));
            Assert.That(attacker.HP, Is.EqualTo(0));
            Assert.That(attacker.IsAlive, Is.EqualTo(false));
            Assert.That(defenser.IsAlive, Is.EqualTo(false));
            Assert.That(history.Attacker.FinishingHP, Is.EqualTo(0));
            Assert.That(history.Defenser.FinishingHP, Is.EqualTo(0));
        }

        [Test]
        public void FightTest_Other_Win_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { IsAlive = true, HP = 20, AttackChance = new FighterDomainModel() { DefaultHP = 100 } };
            Fighter attacker = new Knight()
            {
                Id = 1,
                IsAlive = true,
                HP = 100,
                Paired = true
            };
            Fighter defenser = new Archer()
            {
                Id = 2,
                IsAlive = true,
                HP = 100,
                Paired = true
            };

            FightingCouple couple = new() { Attacker = attacker, Defenser = defenser };

            BattleHistoryEvent history = new(couple, 1);

            // Act
            battle.Fight(-100, couple, history);

            // Assert
            Assert.That(defenser.HP, Is.EqualTo(50));
            Assert.That(attacker.HP, Is.EqualTo(0));
            Assert.That(attacker.IsAlive, Is.EqualTo(false));
            Assert.That(defenser.IsAlive, Is.EqualTo(true));
            Assert.That(history.Attacker.FinishingHP, Is.EqualTo(0));
            Assert.That(history.Defenser.FinishingHP, Is.EqualTo(50));
        }

        [Test]
        public void FightTest_Both_Of_Them_Survive_Should_Be_OK()
        {
            // Arrange
            Fighter fighter = new() { IsAlive = true, HP = 20, AttackChance = new FighterDomainModel() { DefaultHP = 100 } };
            Fighter attacker = new Knight()
            {
                Id = 1,
                IsAlive = true,
                HP = 80,
                Paired = true
            };
            Fighter defenser = new Archer()
            {
                Id = 2,
                IsAlive = true,
                HP = 100,
                Paired = true
            };

            FightingCouple couple = new() { Attacker = attacker, Defenser = defenser };

            BattleHistoryEvent history = new(couple, 1);

            // Act
            battle.Fight(0, couple, history);

            // Assert
            Assert.That(defenser.HP, Is.EqualTo(50));
            Assert.That(attacker.HP, Is.EqualTo(40));
            Assert.That(attacker.IsAlive, Is.EqualTo(true));
            Assert.That(defenser.IsAlive, Is.EqualTo(true));
            Assert.That(history.Attacker.FinishingHP, Is.EqualTo(40));
            Assert.That(history.Defenser.FinishingHP, Is.EqualTo(50));
        }
    }
}
