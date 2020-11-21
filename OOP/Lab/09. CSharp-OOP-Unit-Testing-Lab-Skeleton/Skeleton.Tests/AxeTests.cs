using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]

    public void Axe_Should_Lose_Durability_After_EachAttack()
    {
        // Arrange
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        // Act
        axe.Attack(dummy);
        int expectedResult = 9;
        int actualResult = axe.DurabilityPoints;

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Broken_Axe_Should_Throw_Invalid_Operation_Exception_When_Performing_An_Attack()
    {
        // Arrange
        Axe axe = new Axe(10, 0);
        Dummy dummy = new Dummy(10, 10);

        // Act-Assert
        Assert.Throws<InvalidOperationException>( () => axe.Attack(dummy));
    }
}