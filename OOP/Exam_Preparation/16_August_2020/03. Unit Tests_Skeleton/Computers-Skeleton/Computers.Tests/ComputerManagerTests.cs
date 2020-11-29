using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void Computer_Constructor_Should_Work_Properly_With_Correct_Args()
        {
            // Arange
            Computer computer = new Computer("Lenovo", "500X", 1000m);

            // Act - Assert
            Assert.AreEqual("Lenovo", computer.Manufacturer);
            Assert.AreEqual("500X", computer.Model);
            Assert.AreEqual(1000, computer.Price);
        }

        [Test]
        public void Constructor_Should_Initialize_An_Empty_Collection()
        {
            // Arange
            ComputerManager manager = new ComputerManager();

            // Act
            int expectedResult = 0;
            int actualResult = manager.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Computers_Should_Return_An_IReadOnlyCollection()
        {
            // Arange
            ComputerManager manager = new ComputerManager();

            // Act
            IReadOnlyCollection<Computer> expectedResult = new List<Computer>().AsReadOnly();
            IReadOnlyCollection<Computer> actualResult = manager.Computers;

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void When_Empty_Computer_Tries_To_Be_Added_Argument_Null_Exception_Should_Be_Thrown()
        {
            // Arange
            ComputerManager manager = new ComputerManager();
            Computer computer = null;

            // Act - Assert
            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(computer),
                "Can not be null!");
            // TODO: check if exc msg should be added
        }

        [Test]
        public void When_Same_Computer_Tries_To_Be_Added_Argument_Exception_Should_Be_Thrown()
        {
            // Arange
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Lenovo", "500X", 1000m);
            Computer sameComputer = new Computer("Lenovo", "500X", 1000m);

            // Act - Assert
            manager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => manager.AddComputer(sameComputer),
                "This computer already exists.");
        }

        [Test]
        public void Add_Computer_Method_Should_Add_An_Valid_Computer()
        {
            // Arange
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Lenovo", "500X", 1000m);

            // Act 
            manager.AddComputer(computer);
            int expectedResult = 1;
            int actualResult = manager.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Get_Computer_Method_Should_Throw_Argument_Exception_When_No_Computer_Is_Found()
        {
            // Arange
            ComputerManager manager = new ComputerManager();

            // Act - Assert
            Assert.Throws<ArgumentException>(() => manager.GetComputer("NotExisting", "Nope"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        [TestCase(null)]

        public void Get_Computer_Method_Should_Throw_Argument_Null_Exception_When_Null_Arg_Is_Given(string test)
        {
            // Arange
            ComputerManager manager = new ComputerManager();

            // Act - Assert
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(test, "Nope"),
                "Can not be null!");
        }

        [Test]

        public void Get_Computer_Method_Should_Return_Found_Computer()
        {
            // Arange
            ComputerManager manager = new ComputerManager();
            Computer expectedReuslt = new Computer("Lenovo", "500X", 1000m);

            // Act 
            manager.AddComputer(expectedReuslt);
            Computer actualResult = manager.GetComputer("Lenovo", "500X");

            //Assert
            Assert.AreEqual(expectedReuslt, actualResult);
        }

        [Test]

        public void Remove_Computer_Method_Should_Remove_And_Return_Found_Computer()
        {
            // Arange
            ComputerManager manager = new ComputerManager();
            Computer expectedComputer = new Computer("Lenovo", "500X", 1000m);

            // Act 
            manager.AddComputer(expectedComputer);
            Computer actualComputer = manager.RemoveComputer("Lenovo", "500X");
            int actualCount = 0;
            int expectedCount = manager.Count;

            //Assert
            Assert.AreEqual(expectedComputer, actualComputer);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]

        public void Get_Computers_By_Manufacturer_Method_Should_Return_A_List_Of_Computers()
        {
            // Arange
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Lenovo", "500X", 1000m);
            Computer computerTwo = new Computer("Lenovo", "500S", 10000m);

            // Act
            manager.AddComputer(computer);
            manager.AddComputer(computerTwo);
            List<Computer> expectedReuslt = new List<Computer>() { computer, computerTwo };
            List<Computer> actualReuslt = (List<Computer>)manager.GetComputersByManufacturer("Lenovo");

            //Assert
            CollectionAssert.AreEqual(expectedReuslt, actualReuslt);
        }

        [Test]

        public void Get_Computers_By_Manufacturer_Method_Should_Return_0_When_No_Matches_Are_Found()
        {
            // Arange
            ComputerManager manager = new ComputerManager();

            // Act
            int expectedReuslt = 0;
            int actualReuslt = manager.GetComputersByManufacturer("Lenovo").Count;

            //Assert
            Assert.AreEqual(expectedReuslt, actualReuslt);
        }

        [Test]
        public void Get_Computer_By_Manufacturer_Method_Should_Throw_Argument_Null_Exception_When_Null_Arg_Is_Given()
        {
            // Arange
            ComputerManager manager = new ComputerManager();

            // Act - Assert
            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null),
                "Can not be null!");
        }
    }
}