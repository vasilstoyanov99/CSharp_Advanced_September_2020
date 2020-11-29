using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Constructor_Should_Inititalize_New_Empty_Dictionary()
        {
            // Arange
            RaceEntry raceEntry = new RaceEntry();

            // Act
            int expectedResult = 0;
            int actualResult = raceEntry.Counter;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        
        }

        [Test]

        public void When_Adding_Null_Driver_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arange
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver nullDriver = null;

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(nullDriver),
                "Driver cannot be null.");
        }

        [Test]

        public void When_Adding_Existing_Driver_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arange
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("Test 5000", 420, 69);
            UnitDriver unitDriver = new UnitDriver("Test", unitCar);
            UnitDriver sameUnitDriver = new UnitDriver("Test", unitCar);
            raceEntry.AddDriver(unitDriver);

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(sameUnitDriver),
               "Driver Test is already added.");
        }

        [Test]

        public void Add_Driver_Method_Should_Work_Properly_Under_Correct_Data()
        {
            // Arange
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("Test 5000", 420, 69);
            UnitDriver unitDriver = new UnitDriver("Test", unitCar);

            // Act
            raceEntry.AddDriver(unitDriver);
            int expectedResult = 1;
            int actualResult = raceEntry.Counter;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]

        public void After_Successfully_Added_Driver_String_Result_Should_Be_Returned()
        {
            // Arange
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("Test 5000", 420, 69);
            UnitDriver unitDriver = new UnitDriver("Test", unitCar);

            // Act
            string expectedResult = "Driver Test added in race.";
            string actualResult = raceEntry.AddDriver(unitDriver);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void When_Drivers_Count_Is_Under_2_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arange
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("Test 5000", 420, 69);
            UnitDriver unitDriver = new UnitDriver("Test", unitCar);

            // Act - Arrange
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(),
                "The race cannot start with less than 2 participants.");
        }

        [Test]

        public void Calculate_Average_Horse_Power_Method_Should_Return_Correct_Result()
        {
            // Arange
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("Test 5000", 100, 50);
            UnitDriver unitDriver = new UnitDriver("Test", unitCar);
            UnitDriver unitDriverTwo = new UnitDriver("TestTwo", unitCar);

            // Act
            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriverTwo);
            double expectedResult = 100;
            double actualResult = raceEntry.CalculateAverageHorsePower();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}