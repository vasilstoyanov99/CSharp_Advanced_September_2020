using System;
using System.Collections.Generic;
using NUnit.Framework;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Empty_Constructor_Should_Initialize_Empty_IReadOnlyCollection_Of_Warrior()
        {
            // Arrange
            Arena arena = new Arena();

            // Act
            IReadOnlyCollection<Warrior> expectedResult = new List<Warrior>();
            IReadOnlyCollection<Warrior> actualResult = arena.Warriors;

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void
            Enrolling_Warrior_With_The_Same_Name_Should_Lead_To_Invalid_Operation_Exception()
        {
            // Arrange
            Warrior warrior = new Warrior("Pesho", 10, 100);
            Warrior warriorTwo = new Warrior("Pesho", 20, 100);
            Arena arena = new Arena();

            // Act - Assert
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warriorTwo),
                "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Enroll_Method_Should_Add_Warrior()
        {
            // Arrange
            Warrior warrior = new Warrior("Pesho", 10, 100);
            Arena arena = new Arena();

            // Act
            arena.Enroll(warrior);
            int expectedResult = 1;
            int actualResult = arena.Warriors.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Count_Should_Return_The_Count_Of_Warriors()
        {
            // Arrange
            Warrior warrior = new Warrior("Pesho", 10, 100);
            Warrior warriorTwo = new Warrior("Two", 20, 100);
            Arena arena = new Arena();

            // Act
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);
            int expectedResult = 2;
            int actualResult = arena.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void
            When_Attacker_Does_Not_Exists_In_Arena_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arrange
            Warrior defender = new Warrior("Pesho", 10, 100);
            string attackerName = "NotExisting";
            Arena arena = new Arena();

            // Act - Assert
            arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, "Pesho"),
                "There is no fighter with name NotExisting enrolled for the fights!");
        }

        [Test]
        public void
            When_Defender_Does_Not_Exists_In_Arena_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arrange
            Warrior atteacker = new Warrior("Pesho", 10, 100);
            string defenderName = "NotExisting";
            Arena arena = new Arena();

            // Act - Assert
            arena.Enroll(atteacker);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho", defenderName),
                "There is no fighter with name NotExisting enrolled for the fights!");
        }

        [Test]
        public void
            Attacker_Should_Attack_Defender_When_Both_Exist()
        {
            // Arrange
            Warrior defender = new Warrior("Defender", 10, 100);
            Warrior attacker = new Warrior("Attacker", 20, 100);
            Arena arena = new Arena();

            // Act
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight("Attacker", "Defender");
            int expectedAttackerHP = 90;
            int actualAttackerHP = attacker.HP;
            int expectedDefenderHP = 80;
            int actualDefenderHP = defender.HP;

            // Assert
            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
        }
    }
}
