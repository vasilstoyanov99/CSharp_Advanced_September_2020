using System;

using FakeAxeAndDummy.Contracts;

public class Dummy : IDummy
{
    public Dummy(int health, int experience)
    {
        Health = health;
        Experience = experience;
    }

    public int Health { get; set; }

    public int Experience { get; set; }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        Health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return Experience;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }
}
