
namespace FakeAxeAndDummy.Contracts
{
    public interface IDummy
    {
        public int Health { get; }

        public void TakeAttack(int attackPoints);

        public int GiveExperience();

        public bool IsDead();
    }
}
