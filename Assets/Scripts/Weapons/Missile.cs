using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals.Weapons
{
    class Missile : IWeapon
    {
        private double _missileDamage;

        public string Name { get; set;}
        public string Damage { get { return _missileDamage.ToString(); } }

        public Missile(double damage, string name)
        {
            _missileDamage = damage;
            Name = name;
        }
        public void HeavyAttack(Player player)
        {
            Attack(player, _missileDamage * 1.5);
        }

        public void NormalAttack(Player player)
        {
            Attack(player, _missileDamage);
        }

        public void QuickAttack(Player player)
        {
            Attack(player, _missileDamage * 1.25);
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
            throw new NotImplementedException();
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
