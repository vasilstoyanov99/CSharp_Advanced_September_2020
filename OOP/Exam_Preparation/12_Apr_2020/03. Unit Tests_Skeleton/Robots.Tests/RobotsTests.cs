using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]

        public void SetUp()
        {
            robot = new Robot("Test", 100);
            robotManager = new RobotManager(1);
        }

        [Test]
        public void RobotConstructor_ShouldWorkAsExpected_WhenGivenValidArguments()
        {
            // Assert
            Assert.AreEqual("Test", robot.Name);
            Assert.AreEqual(100, robot.MaximumBattery);
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void RobotManagerConstructor_ShouldWorkAsExpected_WhenGivenValidArgument()
        {
            // Assert
            Assert.AreEqual(0, robotManager.Count);
            Assert.AreEqual(1, robotManager.Capacity);
        }

        [Test]
        public void RobotManagerConstructor_ShouldThrowAnException_WhenGivenInvalidArgument()
        {

            // Assert
            Assert.Throws<ArgumentException>(() => robotManager = new RobotManager(-1));
        }

        [Test]
        public void AddRobot_ShouldThrowAnException_WhenGivenInvalidArgument()
        {
            //Arrange
            Robot robot2 = new Robot("Test2", 50);
            // Act
            robotManager.Add(robot);

            // Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot2));

        }

        [Test]
        public void AddRobot_ShouldWorkAsExpected_WhenGivenValidArguments()
        {
            // Act
            robotManager.Add(robot);

            // Assert
            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RemoveRobot_ShouldThrowAnException_WhenGivenInvalidArgument()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Test"));
        }

        [Test]
        public void RemoveRobot_ShouldWorkAsExpected_WhenGivenValidArguments()
        {
            // Act
            robotManager.Add(robot);
            robotManager.Remove("Test");

            // Assert
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void Work_ShouldThrowAnException_WhenGivenInvalidArgument()
        {
            // Act
            robotManager.Add(robot);

            // Assert
            Assert.Throws<InvalidOperationException>
                (() => robotManager.Work("test", "chill", 0));
            Assert.Throws<InvalidOperationException>
                (() => robotManager.Work("Test", "chill", 200));
        }

        [Test]
        public void Work_ShouldWorkAsExpected_WhenGivenValidArguments()
        {
            // Act
            robotManager.Add(robot);
            robotManager.Work("Test", "chill", 20);

            // Assert
            Assert.AreEqual(robot.Battery, 80);
        }

        [Test]
        public void Charge_ShouldThrowAnException_WhenGivenInvalidArgument()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("test"));
        }

        [Test]
        public void Charge_ShouldWorkAsExpected_WhenGivenValidArguments()
        {
            // Act
            robotManager.Add(robot);
            robotManager.Work("Test", "chill", 20);
            robotManager.Charge("Test");

            // Assert
            Assert.AreEqual(robot.Battery, robot.MaximumBattery);
        }
    }
}
