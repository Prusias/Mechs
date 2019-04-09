using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals
{
    public interface IWeapon
    {
        string Name { get; set; }
        void QuickAttack(Player player);
        void NormalAttack(Player player);
        void HeavyAttack(Player player);
        void UpdateWeaponDamage(double weaponDamageToBeAddedOrSubtracted);
        
    }
}
