using System;

using FakeAxeAndDummy.Contracts;

public class Axe : IWeapon
{
    public Axe(int attack, int durability)
    {
        AttackPoints = attack;
        DurabilityPoints = durability;
    }

    public int AttackPoints { get; set; }

    public int DurabilityPoints { get; set; }

    public void Attack(IDummy target)
    {
        if (DurabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(AttackPoints);
        DurabilityPoints -= 1;
    }
}
