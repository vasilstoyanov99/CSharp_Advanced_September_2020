using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Storing_Array_Capacity_Should_Be_Exactly_16_Integers()
        {
            // Arrange
            int[] testArray = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(testArray);

            // Act
            int expectedResult = 16;
            int actualResult = database.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }      

        [Test]

        public void Add_Operation_Should_Add_An_Element_At_The_Next_Free_Cell()
        {
            // Arrange
            int[] testArray = { 1 };
            Database database = new Database(testArray);

            // Act
            database.Add(2);
            int expectedResult = 2;
            int actualResult = database.Fetch()[1];
            int actualCount = 2;
            int expectedCount = database.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]

        public void Add_Operation_Should_Throw_Invalid_Operation_Exception_If_Array_Length_Is_16_Elements()
        {
            // Arrange
            int[] testArray = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(testArray);

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]

        public void Remove_Operation_Should_Support_Only_Remove_An_Element_At_The_Last_Index()
        {
            // Arrange
            int[] testArray = { 1, 2 };
            Database database = new Database(testArray);

            // Act
            database.Remove();
            int expectedResult = 1;
            int actualResult = database.Fetch()[0];
            int actualCount = 1;
            int expectedCount = database.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]

        public void Empty_Database_Should_Throw_Invalid_Operation_Exception_When_Using_Remove_Method()
        {
            // Arrange
            Database database = new Database();

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]

        public void Fetch_Method_Should_Return_The_Elements_As_Array()
        {
            // Arrange
            int[] expectedResult = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(expectedResult);

            // Act
            int[] actualResult = database.Fetch();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}