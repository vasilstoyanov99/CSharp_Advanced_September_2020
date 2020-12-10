using System;
using System.Linq.Expressions;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]

        public void NameProperty_ShouldThrowAnException_WhenGivenInvalidArgument(string test)
        {
            // Arrange
            Computer computer;

            // Act - Assert 
            Assert.Throws<ArgumentNullException>(() => computer = new Computer(test));
        }

        [Test]
        public void NameProperty_ShouldSetName_WhenGivenValidArgument()
        {
            //Arrange
            Computer computer = new Computer("Test");

            // Assert 
            Assert.AreEqual(computer.Name, "Test");
        }

        [Test]
        public void Constructor_ShouldInitializeAnEmptyCollection()
        {
            //Arrange
            Computer computer = new Computer("Test");

            // Assert
            Assert.AreEqual(computer.Parts.Count, 0);
        }

        [Test]
        public void TotalPrice_WorkAsExpected_WhenGivenValidArgument()
        {
            Computer computer = new Computer("Test");
            Part part = new Part("Test", 100);
            Part part2 = new Part("Test2", 100);

            // Act
            computer.AddPart(part);
            computer.AddPart(part2);

            // Assert
            Assert.AreEqual(computer.TotalPrice, 200);
        }

        [Test]
        public void AddPart_ShouldThrowAnException_WhenGivenInvalidArgument()
        {
            //Arrange
            Computer computer = new Computer("Test");

            // Assert
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void AddPart_WorkAsExpected_WhenGivenValidArgument()
        {
            //Arrange
            Computer computer = new Computer("Test");
            Part part = new Part("Test", 500);

            // Act
            computer.AddPart(part);
            
            // Assert
            Assert.AreEqual(computer.Parts.Count, 1);
        }

        [Test]
        public void RemovePart_WorkAsExpected_WhenGivenValidArgument()
        {
            //Arrange
            Computer computer = new Computer("Test");
            Part part = new Part("Test", 500);

            // Act
            computer.AddPart(part);
            bool actualResult =  computer.RemovePart(part);

            // Assert
            Assert.AreEqual(0, computer.Parts.Count);
            Assert.AreEqual(true, actualResult);
        }

        [Test]
        public void RemovePart_ShouldReturnFalse_WhenGivenPartWhichIsNotInThePartsCollection()
        {
            //Arrange
            Computer computer = new Computer("Test");
            Part part = new Part("Test", 500);

            // Act
            bool actualResult = computer.RemovePart(part);

            // Assert
            Assert.AreEqual(0, computer.Parts.Count);
            Assert.AreEqual(false, actualResult);
        }

        [Test]
        public void GetPart_ShouldReturnNull_WhenGivenInValidArgument()
        {
            //Arrange
            Computer computer = new Computer("Test");

            // Assert
            Assert.AreEqual(computer.GetPart("Test"), null);
        }

        [Test]
        public void GetPart_WorkAsExpected_WhenGivenValidArgument()
        {
            //Arrange
            Computer computer = new Computer("Test");
            Part part = new Part("Test", 500);

            // Act
            computer.AddPart(part);

            // Assert
            Assert.AreEqual(computer.GetPart("Test"), part);
        }
    }
}