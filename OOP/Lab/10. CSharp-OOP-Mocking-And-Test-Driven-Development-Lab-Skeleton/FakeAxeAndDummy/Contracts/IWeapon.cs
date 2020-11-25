﻿
namespace FakeAxeAndDummy.Contracts
{
    public interface IWeapon
    {
        public int AttackPoints { get; }

        public int DurabilityPoints { get; }

        public void Attack(IDummy target);
    }
}
