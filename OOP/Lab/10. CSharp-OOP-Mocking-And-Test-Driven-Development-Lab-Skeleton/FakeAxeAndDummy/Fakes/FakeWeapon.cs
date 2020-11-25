
using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy.Fakes
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints { get; set; }

        public int DurabilityPoints { get; set; }

        public void Attack(IDummy target)
        {
            target.TakeAttack(AttackPoints);
            DurabilityPoints -= 1;
        }
    }
}
