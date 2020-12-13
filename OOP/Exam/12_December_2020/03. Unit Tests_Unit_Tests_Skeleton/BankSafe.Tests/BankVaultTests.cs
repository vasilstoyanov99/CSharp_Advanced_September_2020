using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldInitializeACollection()
        {
            BankVault bankVault = new BankVault();
            var expectedResult = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            CollectionAssert.AreEqual(expectedResult.ToImmutableDictionary(), bankVault.VaultCells);
            Assert.AreEqual(expectedResult.Count, bankVault.VaultCells.Count);
        }

        [Test]
        public void AddItem_ShouldThrowAnException_WhenGivenInvalidArguments()
        {
            //Arrange
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "500");

            // Act
            bankVault.AddItem("A1", item);

            // Assert
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("does not exist", null));
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", null));
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }

        [Test]
        public void AddItem_ShouldWorkAsExpected_WhenGivenValidArguments()
        {
            //Arrange
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "500");

            // Act
            string expectedReturn =  bankVault.AddItem("A1", item);
            string actualReturn = $"Item:{item.ItemId} saved successfully!";
            Item actualItem = bankVault.VaultCells["A1"];

            // Assert
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(item, actualItem);
        }

        [Test]
        public void RemoveItem_ShouldThrowAnException_WhenGivenInvalidArguments()
        {
            //Arrange
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "500");

            // Act
            bankVault.AddItem("A1", item);

            // Assert
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("does not exist", null));
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", null));
        }

        [Test]
        public void RemoveItem_ShouldWorkAsExpected_WhenGivenValidArguments()
        {
            // Arrange
            BankVault bankVault = new BankVault();
            Item item = new Item("Test", "500");

            // Act
            bankVault.AddItem("A1", item);
            string expectedReturn = bankVault.RemoveItem("A1", item);
            string actualReturn = $"Remove item:{item.ItemId} successfully!";
            Item actualItem = bankVault.VaultCells["A1"];

            // Assert
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(null, actualItem);
        }
    }
}