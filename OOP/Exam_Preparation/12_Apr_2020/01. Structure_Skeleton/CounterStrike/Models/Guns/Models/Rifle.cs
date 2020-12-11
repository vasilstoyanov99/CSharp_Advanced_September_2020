using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Models
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (BulletsCount - 10 >= 0)
            {
                BulletsCount -= 10;
                return 10;
            }

            return 0;
        }
    }
}
