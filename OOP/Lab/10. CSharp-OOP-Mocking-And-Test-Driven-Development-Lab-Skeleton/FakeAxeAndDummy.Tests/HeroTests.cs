using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [SetUp]

    public void SetUp()
    {

    }

    [Test]
    public void Dummy_Should_Give_Experience_When_Becomes_Dead_After_Being_Attacked
        ()
    {
        // Arrange
        Mock<IDummy> fakeDummy = new Mock<IDummy>();
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero("Hero", fakeWeapon.Object);
        fakeDummy.Setup(x => x.IsDead()).Returns(true);
        fakeDummy.Setup(x => x.GiveExperience()).Returns(15);

        // Act
        hero.Attack(fakeDummy.Object);
        int expectedResult = 15;
        int actualResult = hero.Experience;

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}