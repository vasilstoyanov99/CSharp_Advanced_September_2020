using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
     public void Dummy_Should_Lose_Health_When_Attacked()
     {
         // Arrange
         Axe axe = new Axe(1, 10);
         Dummy dummy = new Dummy(10, 10);

         // Act
         axe.Attack(dummy);
         int expectedResult = 9;
         int actualResult = dummy.Health;

         // Assert
         Assert.AreEqual(expectedResult, actualResult);
     }

     [Test]
     public void Dead_Dummy_Should_Throw_Invalid_Operation_Exception_When_Attacked()
     {
         // Arrange
         Axe axe = new Axe(1, 10);
         Dummy dummy = new Dummy(0, 10);

         // Act - Assert
         Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
     }

     [Test]
     public void Dead_Dummy_Should_Give_XP()
     {
         // Arrange
         Dummy dummy = new Dummy(0, 10);

         // Act
         int expectedResult = 10;
         int actualResult = dummy.GiveExperience();

         // Assert
         Assert.AreEqual(expectedResult, actualResult);
     }

     [Test]
     public void Alive_Dummy_Should_Not_Give_XP_It_Shold_Throw_Invalid_Operation_Exception()
     {
         // Arrange
         Dummy dummy = new Dummy(10, 10);

         // Act - Assert
         Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
     }
}
