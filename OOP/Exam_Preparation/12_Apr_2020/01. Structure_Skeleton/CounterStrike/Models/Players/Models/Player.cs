using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players.Models
{
    public abstract class Player : IPlayer
    {
        private string _username;
        private int _health;
        private int _armor;
        private IGun _gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get => _username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                _username = value;
            }
        }

        public int Health
        {
            get => _health;

            private set // TODO: Check if set should be protected
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                _health = value;
            }
        }

        public int Armor
        {
            get => _armor;

            private set // TODO: Check if set should be protected
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                _armor = value;
            }
        }

        public IGun Gun
        {
            get => _gun;

            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                _gun = value;
            }
        }

        public bool IsAlive
        {
            get => Health > 0;
        }

        public void TakeDamage(int points)
        {
            Armor -= points;

            if (Armor - points > 0)
            {
                Armor -= points;
                return;
            }
            else
            {
                points -= Armor;
                Armor = 0;
            }

            Health -= points;
        }
    }
}
