using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car carTest;

        [SetUp]
        public void Setup()
        {
            carTest = new Car("Mercedes", "S class", 10.00, 50.00);
        }

        [Test]
        public void Constructor_Should_Set_Properties_Properly()
        {
            // Arrange
            string make = "Mercedes";
            string model = "S class";
            double fuelConsumption = 10.00;
            double fuelCapacity = 50.00;
            double fuelAmount = 0;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            // Act
            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumptionl = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;
            double actualFuelAmount = car.FuelAmount;

            // Assert
            Assert.AreEqual(make, actualMake);
            Assert.AreEqual(model, actualModel);
            Assert.AreEqual(fuelConsumption, actualFuelConsumptionl);
            Assert.AreEqual(fuelCapacity, actualFuelCapacity);
            Assert.AreEqual(fuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void Make_Setter_Should_Throw_Argument_Exception_When_Value_Is_Null_Or_Empty(string make)
        {
            // Arrange
            Car car;

            // Act - Assert
            Assert.Throws<ArgumentException>(() => car = new Car(make, "S class", 10, 60),
                "Make cannot be null or empty!");
        }

        [Test]
        public void Make_Getter_Should_Retrun_Proper_Data()
        {
            // Arrange
            string expectedMake = "Mercedes";
            Car car = new Car(expectedMake, "S class", 10, 60);

            // Act
            string actualMake = car.Make;

            // Assert
            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void Model_Setter_Should_Throw_Argument_Exception_When_Value_Is_Null_Or_Empty(string model)
        {
            // Arrange
            Car car;

            // Act - Assert
            Assert.Throws<ArgumentException>(() => car = new Car("Mercedes", model, 10, 60),
                "Model cannot be null or empty!");
        }

        [Test]
        public void Model_Getter_Should_Retrun_Proper_Data()
        {
            // Arrange
            string expectedModel = "S class";
            Car car = new Car("Mercedes", expectedModel, 10, 60);

            // Act
            string actualModel = car.Model;

            // Assert
            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10.00)]

        public void
            Fuel_Consumption_Setter_Should_Throw_Argument_Exception_When_Value_Is_Zero_Or_Negative
            (double fuelConsumption)
        {
            // Arrange
            Car car;

            // Act - Assert
            Assert.Throws<ArgumentException>(() => car = new Car("Mercedes", "S class", fuelConsumption, 60.00),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void Fuel_Consumption_Getter_Should_Retrun_Proper_Data()
        {
            // Arrange
            double expectedFuelConsumption = 10.00;
            Car car = new Car("Mercedes", "S class", expectedFuelConsumption, 60.00);

            // Act
            double actualFuelConsumption = car.FuelConsumption;

            // Assert
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-60.00)]

        public void
            Fuel_Capacity_Setter_Should_Throw_Argument_Exception_When_Value_Is_Zero_Or_Negative
            (double fuelAmount)
        {
            // Arrange
            Car car;

            // Act - Assert
            Assert.Throws<ArgumentException>(() => car = new Car("Mercedes", "S class", 10.00, fuelAmount),
                "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void Fuel_Capacity_Getter_Should_Retrun_Proper_Data()
        {
            // Arrange
            double expectedFuelCapacity = 60.00;
            Car car = new Car("Mercedes", "S class", 10.00, expectedFuelCapacity);

            // Act
            double actualFuelCapacity = car.FuelCapacity;

            // Assert
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void Fuel_Amount_Getter_Should_Retrun_Proper_Data()
        {
            // Arrange
            double expectedFuelAmount = 0;
            Car car = new Car("Mercedes", "S class", 10.00, 60.00);

            // Act
            double actualFuelAmount = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-60.00)]

        public void
            Refuel_Method_Should_Throw_Argument_Exception_When_Value_Is_Zero_Or_Negative
            (double fuelToRefuel)
        {
            // Arrange
            Car car = new Car("Mercedes", "S class", 10.00, 60.00);

            // Act - Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel),
                "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void Fuel_Amount_Should_Be_Increased_Wnen_Using_Refuel_Method()
        {
            // Arrange
            Car car = new Car("Mercedes", "S class", 10.00, 60.00);
            double fuelToRefuel = 10.00;
            car.Refuel(fuelToRefuel);

            // Act
            double expectedFuelAmount = 10.00;
            double actualFuelAmount = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void
            When_Fuel_Amount_Is_More_Than_Fuel_Capacity_The_Amount_Should_Become_Equal_To_The_Capacity()
        {
            // Arrange
            Car car = new Car("Mercedes", "S class", 10.00, 60.00);
            car.Refuel(70.00);

            // Act
            double expectedAmount = 60.00;
            double actualAmount = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void
            Drive_Method_Should_Throw_Invalid_Operation_Exception_When_Needed_Fuel_Is_More_Than_Available_Fuel()
        {
            // Arrange
            Car car = new Car("Mercedes", "S class", 10.00, 60.00);

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(700.00),
                "You don't have enough fuel to drive!");
        }

        [Test]
        public void
            Fuel_Amount_Should_Be_Decreased_When_Successful_Drive_Is_Done()
        {
            // Arrange
            Car car = new Car("Mercedes", "S class", 10.00, 60.00);
            car.Refuel(50.00);
            car.Drive(400.00);

            // Act
            double expectedAmount = 10.00;
            double actualAmount = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }
    }
}