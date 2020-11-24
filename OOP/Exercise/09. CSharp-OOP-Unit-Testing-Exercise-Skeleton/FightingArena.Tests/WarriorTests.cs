using System;
using NUnit.Framework;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private int MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Should_Set_Properties_Properly()
        {
            // Arrange
            string expectedName = "Pesho";
            int expectedDamage = 10;
            int expectedHP = 100;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            // Act
            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            // Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(actualHP, expectedHP);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void Name_Setter_Should_Throw_Argument_Exception_When_Value_Is_Null_Or_Empty(string name)
        {
            // Arrange
            Warrior warrior;

            // Act - Assert
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, 10, 100),
                "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]

        public void Damage_Setter_Should_Throw_Argument_Exception_When_Value_Is_Negative_Or_Zero(int damage)
        {
            // Arrange
            Warrior warrior;

            // Act - Assert
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Pesho", damage, 100),
                "Damage value should be positive!");
        }

        [Test]
        [TestCase(-100)]

        public void HP_Setter_Should_Throw_Argument_Exception_When_Value_Is_Negative_Or_Zero(int HP)
        {
            // Arrange
            Warrior warrior;

            // Act - Assert
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Pesho", 10, HP),
                "HP should not be negative!");
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void When_HP_Is_Not_Enogh_To_Use_Attack_Method_Invalid_Operation_Exception_Should_Be_Thrown
            (int HP)
        {
            // Arrange
            string name = "Pesho";
            int damage = 10;
            Warrior warrior = new Warrior(name, damage, HP);

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(null),
                "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void When_Enemy_HP_Is_Not_Enogh_To_Use_Attack_Method_Invalid_Operation_Exception_Should_Be_Thrown
            (int enemyHP)
        {
            // Arrange
            string name = "Pesho";
            int damage = 10;
            Warrior warrior = new Warrior(name, damage, 40);
            Warrior enemy = new Warrior("Enemy", 10, enemyHP);

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy),
                $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        public void 
            When_Enemy_Damage_Is_More_Than_Warrior_HP_Exception_Should_Be_Thrown_In_Attack_Method()
        {
            // Arrange
            Warrior warrior = new Warrior("Pesho", 10, 40);
            Warrior enemy = new Warrior("Enemy", 50, 50);

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy),
                $"You are trying to attack too strong enemy");
        }

        [Test]
        public void Warrior_HP_Should_Be_Decreased_By_Enemy_Damage_When_Performing_A_Successful_Attack()
        {
            // Arrange
            Warrior warrior = new Warrior("Pesho", 10, 40);
            Warrior enemy = new Warrior("Enemy", 5, 50);

            // Act
            warrior.Attack(enemy);
            int expectedResult = 35;
            int actualResult = warrior.HP;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Enemy_HP_Should_Be_Decreased_By_Warrior_Damage_When_Attacked()
        {
            // Arrange
            Warrior warrior = new Warrior("Pesho", 20, 100);
            Warrior enemy = new Warrior("Enemy", 5, 100);

            // Act
            warrior.Attack(enemy);
            int expectedResult = 80;
            int actualResult = enemy.HP;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Enemy_HP_Should_Become_Zero_When_Warrior_Damage_Is_More()
        {
            // Arrange
            Warrior warrior = new Warrior("Pesho", 50, 100);
            Warrior enemy = new Warrior("Enemy", 5, 40);

            // Act
            warrior.Attack(enemy);
            int expectedResult = 0;
            int actualResult = enemy.HP;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}