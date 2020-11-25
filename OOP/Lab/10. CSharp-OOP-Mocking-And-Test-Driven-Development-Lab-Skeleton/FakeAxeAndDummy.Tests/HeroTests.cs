using FakeAxeAndDummy.Fakes;
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
        FakeDummy fakeDummy = new FakeDummy();
        FakeWeapon fakeWeapon = new FakeWeapon();
        Hero hero = new Hero("Hero", fakeWeapon);

        // Act
        hero.Attack(fakeDummy);
        int expectedResult = 15;
        int actualResult = hero.Experience;

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}