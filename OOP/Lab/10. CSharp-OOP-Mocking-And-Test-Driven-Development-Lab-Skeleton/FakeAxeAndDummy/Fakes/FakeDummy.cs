
using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy.Fakes
{
    public class FakeDummy : IDummy
    {
        public int Health { get; private set; }

        public int Experience => 15;

        public FakeDummy()
        {
            Health = 5;
        }

        public int GiveExperience() => Experience;

        public bool IsDead() =>  Health <= 0;

        public void TakeAttack(int attackPoints)
        {
            Health -= attackPoints;
        }
    }
}
