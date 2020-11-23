using System;
using System.Collections.Generic;
using NUnit.Framework;
using DatabaseExtended;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public void Empty_Constructor_Should_Return_Count_Zero()
        {
            // Arrange
            ExtendedDatabase database = new ExtendedDatabase();

            // Act
            int actualResult = database.Count;
            int expectedResult = 0;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_One_Person_In_The_Constructor_And_Should_Return_Count_One()
        {
            // Arrange
            Person test = new Person(2354, "Test");
            ExtendedDatabase database = new ExtendedDatabase(test);

            // Act
            int expectedResult = 1;
            int actualResult = database.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void 
            Constructor_Should_Throw_An_Exception_If_More_Elements_Than_The_Collection_Size_Are_Added()
        {
            // Arrange
            List<Person> testLsit = new List<Person>();
            Person person;

            for (int i = 1; i <= 17; i++)
            {
                person = new Person(i, i.ToString());
                testLsit.Add(person);
            }

            // Act - Assert
            Assert.Throws<ArgumentException>(() =>
            {
                ExtendedDatabase database
                = new ExtendedDatabase(testLsit.ToArray());
            });
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

            ExtendedDatabase database = new ExtendedDatabase(testLsit.ToArray());
            person = new Person(17, "17");

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]

        public void Add_Method_Should_Work_Correctly()
        {
            // Arrange
            Person expectedResult = new Person(4534543, "Test");
            ExtendedDatabase database = new ExtendedDatabase();

            // Act
            database.Add(expectedResult);
            Person actualResult = database.FindByUsername("Test");

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
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

            ExtendedDatabase database = new ExtendedDatabase(testLsit.ToArray());

            // Act
            int expectedResult = 16;
            int actualResult = database.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }      

        [Test]
        public void Adding_Person_With_Existing_Username_Should_Throw_Invalid_Operation_Exception()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase database = new ExtendedDatabase(testPerson);
            Person sameUsernamePerson = new Person(5235353, "Test");

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(sameUsernamePerson));
        }

        [Test]
        public void Adding_Person_With_Existing_ID_Should_Throw_Invalid_Operation_Exception()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase database = new ExtendedDatabase(testPerson);
            Person sameIDPerson = new Person(2334534634, "TestSecond");

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(sameIDPerson));
        }

        [Test]

        public void When_Person_Added_Count_Should_Be_Increased()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase database = new ExtendedDatabase();

            // Act
            database.Add(testPerson);
            int expectedResult = 1;
            int actualResult = database.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void When_Person_Is_Removed_Count_Should_Be_Decreased()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            Person testPersonTwo = new Person(2, "Test2");
            ExtendedDatabase database 
                = new ExtendedDatabase(testPerson, testPersonTwo);

            // Act
            database.Remove();
            int expectedResult = 1;
            int actualResult = database.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void 
            When_Person_Is_Being_Removed_From_An_Empty_Collection_Invalid_Operation_Exception_Should_Be_Thrown()
        {
            // Arrange
            ExtendedDatabase database = new ExtendedDatabase();

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [Test]

        public void Empty_Database_Should_Throw_Invalid_Operation_Exception_When_Using_Remove_Method()
        {
            // Arrange
            ExtendedDatabase database = new ExtendedDatabase();

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void
            If_Username_Parameter_Is_Null_Or_Empty_Argument_Null_Exception_Should_Be_Thrown
            (string testUsername)
        {
            // Arrange
            ExtendedDatabase database = new ExtendedDatabase();

            // Act - Assert
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(testUsername),
                "The username is not null or whitespace.");
        }


        [Test]

        public void Find_By_Username_Should_Throw_Invalid_Operation_Exception_In_Case_Of_Non_Existing_Username() 
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase database = new ExtendedDatabase(testPerson);
            string fakeUsername = "Fake";

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(fakeUsername));
        }

        

        [Test]

        public void
            Find_By_Username_Method_Should_Work_Properly_With_Case_Sensitive_Arguments()
        {
            // Arrange
            Person expectedResult = new Person(2334534634, "Test");
            Person expectedresult = new Person(2352235, "test");
            ExtendedDatabase database =
                new ExtendedDatabase(expectedResult, expectedresult);

            // Act
            Person actualResult = database.FindByUsername("Test");
            Person actualresult = database.FindByUsername("test");

            // - Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedresult, actualresult);
        }

        [Test]

        public void
           Find_By_Id_Should_Throw_An_Exception_In_Case_Of_Non_Existing_Id()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase database = new ExtendedDatabase(testPerson);
            long fakeId = 5864645453;

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.FindById(fakeId));
        }

        [Test]

        public void
           Find_By_Id_Should_Throw_An_Exception_In_Case_Of_Negative_Id()
        {
            // Arrange
            Person testPerson = new Person(2334534634, "Test");
            ExtendedDatabase database = new ExtendedDatabase(testPerson);
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
            ExtendedDatabase database = new ExtendedDatabase(expectedResult);
            long correctId = 2334534634;

            // Act 
            Person actualResult = database.FindById(correctId);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}