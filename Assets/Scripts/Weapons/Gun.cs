using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals.Weapons
{
    public class Gun : IWeapon
    {
        private double _gunDamage;
        public string Name { get; set; }

        public Gun(double damage, string name)
        {
            _gunDamage = damage;
            Name = name;
        }
        public void HeavyAttack(Player player)
        {
            Attack(player, _gunDamage * 1.25);
        }

        public void NormalAttack(Player player)
        {
            Attack(player, _gunDamage);
        }

        public void QuickAttack(Player player)
        {
            Attack(player, _gunDamage * 0.75);
        }

        private void Attack(Player player, double damage)
        {
            if (PlayerHasEnoughArmour(player, damage))
            {
                player.Armour -= damage;
            }

            if (player.Armour > 0)
            {
                double remainingDamage = damage - player.Armour;
                player.Armour = 0;
                player.Health -= remainingDamage;
                return;

            }

            player.Health -= damage;
        }

        public void UpdateWeaponDamage(double weaponDamageToBeAddedOrSubtracted)
        {
            _gunDamage += weaponDamageToBeAddedOrSubtracted;
        }

        private bool PlayerHasEnoughArmour(Player player, double damage)
        {
            if(player.Armour - damage >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
