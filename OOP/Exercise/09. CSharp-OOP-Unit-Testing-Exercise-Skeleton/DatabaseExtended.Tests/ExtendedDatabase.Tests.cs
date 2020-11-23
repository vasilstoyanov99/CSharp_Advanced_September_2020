using System;
using System.Linq;
using System.Collections.Generic;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Storing_Array_Capacity_Should_Be_Exactly_16_Integers()
        {
            // Arrange
            List<Person> testLsit = new List<Person>();
            Person person;

            for (int i = 1; i <= 16; i++)
            {
                person = new Person(i, i.ToString());
                testLsit.Add(person);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testLsit.ToArray());

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
            Person testOne = new Person(1241, "asd");
            Person expectedResult = new Person(2352, "aefesd");
            Person[] testArray = { testOne };
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testArray);

            // Act
            database.Add(expectedResult);
            Person actualResult = database.Fetch()[1];
            int actualCount = 2;
            int expectedCount = database.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void Add_Operation_Should_Throw_Invalid_Operation_Exception_If_Array_Length_Is_16_Elements()
        {
            // Arrange
            List<Person> testLsit = new List<Person>();
            Person person;

            for (int i = 1; i <= 16; i++)
            {
                person = new Person(i, i.ToString());
                testLsit.Add(person);
            }

            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testLsit.ToArray());
            person = new Person(17, "17");

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]

        public void Remove_Operation_Should_Support_Only_Remove_An_Element_At_The_Last_Index()
        {
            Person expectedResult = new Person(1241, "asd");
            Person test = new Person(2352, "aefesd");
            Person[] testArray = { expectedResult, test };
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testArray);

            // Act
            database.Remove();
            Person actualResult = database.Fetch()[0];
            int actualCount = 1;
            int expectedCount = database.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void Empty_Database_Should_Throw_Invalid_Operation_Exception_When_Using_Remove_Method()
        {
            // Arrange
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase();

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void If_There_Are_Already_Users_With_Same_Input_Username_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testPerson);
            Person sameUsernamePerson = new Person(5235353, "Test");

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(sameUsernamePerson));
        }

        [Test]
        public void If_There_Are_Already_Users_With_Same_Input_ID_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testPerson);
            Person sameIDPerson = new Person(2334534634, "TestSecond");

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(sameIDPerson));
        }

        [Test]

        public void If_Input_Username_Is_Not_In_Database_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testPerson);
            string fakeUsername = "Fake";

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(fakeUsername));
        }

        [Test]

        public void
            If_Input_Username_Parameter_Is_Null_Argument_Null_Exception_Should_Be_Thrown_In_Find_By_Username_Method()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testPerson);
            string emptyUsername = null;

            // Act - Assert
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(emptyUsername));
        }

        [Test]

        public void
            Find_By_Username_Method_Should_Work_Properly_With_Case_Sensitive_Arguments()
        {
            // Arrange
            Person expectedResult = new Person(2334534634, "Test");
            Person expectedresult = new Person(2352235, "test");
            ExtendedDatabase.ExtendedDatabase database =
                new ExtendedDatabase.ExtendedDatabase(expectedResult, expectedresult);

            // Act
            Person actualResult = database.FindByUsername("Test");
            Person actualresult = database.FindByUsername("test");

            // - Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedresult, actualresult);
        }

        [Test]

        public void
           If_Input_ID_Is_Not_In_Database_Invalid_Operation_Exception_Should_Be_Thrown_When_Using_Find_By_Id_Method()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testPerson);
            long fakeId = 5864645453;

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.FindById(fakeId));
        }

        [Test]

        public void
           If_Input_ID_Is_Negative_Argument_Out_Of_Range_Exception_Should_Be_Thrown_When_Using_Find_By_Id_Method()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(testPerson);
            long negativeId = -5864645453;

            // Act - Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(negativeId));
        }

        [Test]

        public void
           Find_By_Id_Method_Should_Work_Properly_With_Correct_Input_Argument()
        {
            // Arrange
            Person expectedResult = new Person(2334534634, "Test");
            ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(expectedResult);
            long correctId = 2334534634;

            // Act 
            Person actualResult = database.FindById(correctId);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void Constructor_Should_Initializa_Array_Of_Person_Classes()
        {
            // Arrange
            Person testOne = new Person(1241, "asd");
            Person testTwo = new Person(2352, "aefesd");
            ExtendedDatabase.ExtendedDatabase database = 
                new ExtendedDatabase.ExtendedDatabase(testOne, testTwo);

            // Act
            Person[] expectedResult = { testOne, testTwo };
            Person[] actualResult = database.Fetch().Take(2).ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}