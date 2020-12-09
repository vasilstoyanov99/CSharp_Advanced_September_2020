using System;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddComputer_ShouldThrowException_WhenInvalidArgumentsAreGiven()
        {
            //Arrange
            ComputerManager computerManager = new ComputerManager();
            Computer testComputer = new Computer("Lenovo", "S 5000", 1000);

            // Act - Assert
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
            computerManager.AddComputer(testComputer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(testComputer));
        }

        [Test]
        public void AddComputer_ShouldWorkAsExpected_WhenValidArgumentsAreGiven()
        {
            //Arrange
            ComputerManager computerManager = new ComputerManager();
            Computer testComputer = new Computer("Lenovo", "S 5000", 1000);

            // Act
            computerManager.AddComputer(testComputer);

            // Assert
            Assert.AreEqual(computerManager.Count, 1);
            Assert.AreEqual(computerManager.Computers.Count, 1);
        }

        [Test]
        public void GetComputer_ShouldThrowException_WhenInvalidArgumentsAreGiven()
        {
            //Arrange
            ComputerManager computerManager = new ComputerManager();

            // Act - Assert
            Assert.Throws<ArgumentNullException>
                (() => computerManager.GetComputer("Test", null));
            Assert.Throws<ArgumentNullException>
                (() => computerManager.GetComputer(null, "Test"));
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("Test", "Test"));
        }

        [Test]
        public void RemoveComputer_ShouldWorkAsExpected_WhenValidArgumentsAreGiven()
        {
            //Arrange
            ComputerManager computerManager = new ComputerManager();
            Computer testComputer = new Computer("Lenovo", "S 5000", 1000);

            // Act
            computerManager.AddComputer(testComputer);

            // Assert
            Assert.AreEqual
                (computerManager.RemoveComputer("Lenovo", "S 5000"), testComputer);
            Assert.AreEqual(computerManager.Count, 0);
            Assert.AreEqual(computerManager.Computers.Count, 0);
        }

        [Test]
        public void GetComputersByManufacturer_ShouldThrowException_WhenInvalidArgumentsAreGiven()
        {
            //Arrange
            ComputerManager computerManager = new ComputerManager();

            // Act - Assert
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));

        }

        [Test]
        public void GetComputersByManufacturer_ShouldWorkAsExpected_WhenValidArgumentsAreGiven()
        {
            //Arrange
            ComputerManager computerManager = new ComputerManager();
            Computer testComputer = new Computer("Lenovo", "S 5000", 1000);
            Computer testComputer2 = new Computer("Lenovo", "S 6000", 1600);
            Computer testComputer3 = new Computer("Test", "S 8000", 1500);

            // Act
            computerManager.AddComputer(testComputer);
            computerManager.AddComputer(testComputer2);
            computerManager.AddComputer(testComputer3);
            var result = computerManager.GetComputersByManufacturer("Lenovo");

            // Assert
            CollectionAssert.Contains(result, testComputer);
            CollectionAssert.Contains(result, testComputer2);
            CollectionAssert.DoesNotContain(result, testComputer3);
        }
    }
}