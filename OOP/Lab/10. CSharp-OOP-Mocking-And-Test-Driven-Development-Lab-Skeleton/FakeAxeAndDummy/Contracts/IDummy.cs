
namespace FakeAxeAndDummy.Contracts
{
    public interface IDummy
    {
        public int Health { get; set; }

        public int Experience { get; set; }

        public void TakeAttack(int attackPoints);

        public int GiveExperience();

        public bool IsDead();
    }
}
