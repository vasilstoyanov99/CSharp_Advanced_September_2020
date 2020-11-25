
namespace FakeAxeAndDummy.Contracts
{
    public interface IWeapon
    {
        public int AttackPoints { get; set; }

        public int DurabilityPoints { get; set; }

        public void Attack(IDummy target);
    }
}
