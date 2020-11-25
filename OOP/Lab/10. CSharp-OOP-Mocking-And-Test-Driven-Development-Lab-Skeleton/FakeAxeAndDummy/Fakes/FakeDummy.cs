
using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy.Fakes
{
    public class FakeDummy : IDummy
    {
        public int Health { get; set; }

        public int Experience { get; set; }

        public int GiveExperience() => Experience;

        public bool IsDead() =>  Health <= 0;

        public void TakeAttack(int attackPoints)
        {
            Health -= attackPoints;
        }
    }
}
