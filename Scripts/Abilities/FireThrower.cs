using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals.Abilities
{
    public class FireThrower : IAbility
    {
        private double _heathDamage;

        public FireThrower(double damage)
        {
            _heathDamage = damage;
        }
        public void Cast(Player player)
        {
            player.Heat += _heathDamage;
        }

        public void UpdateDamage(double damageToBeAddedOrSubtracted)
        {
            _heathDamage += damageToBeAddedOrSubtracted;
        }
    }
}
