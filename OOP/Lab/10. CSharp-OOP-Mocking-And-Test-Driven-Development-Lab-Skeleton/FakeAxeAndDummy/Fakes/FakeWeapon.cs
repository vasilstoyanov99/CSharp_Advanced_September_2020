
using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy.Fakes
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints { get; private set; }

        public FakeWeapon()
        {
            DurabilityPoints = 20;
        }

        public void Attack(IDummy target)
        {
            target.TakeAttack(AttackPoints);
            DurabilityPoints -= 1;
        }
    }
}
