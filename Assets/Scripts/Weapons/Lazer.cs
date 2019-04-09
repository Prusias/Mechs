using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals.Weapons
{
    public class Lazer : IWeapon
    {
        private double _lazerDamage;

        public string Name { get; set; }

        public Lazer(double damage, string name)
        {
            _lazerDamage = damage;
            Name = name;
        }
        public void HeavyAttack(Player player)
        {
            Attack(player, _lazerDamage * 1.25);
        }

        public void NormalAttack(Player player)
        {
            Attack(player, _lazerDamage);
        }

        public void QuickAttack(Player player)
        {
            Attack(player, _lazerDamage * 0.75);
        }

        private void Attack(Player player, double damage)
        {
            if (PlayerHasEnoughArmour(player, damage))
            {
                player.Armour -= damage;
                return;
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
            _lazerDamage += weaponDamageToBeAddedOrSubtracted;
        }

        private bool PlayerHasEnoughArmour(Player player, double damage)
        {
            if (player.Armour - damage >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
