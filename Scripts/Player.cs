using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals
{
    public class Player
    {
        public string Name { get; set; }
        public double Health { get; set; }
        //Heat represents mana, once a player overheats he cannot attack that turn
        public double Heat { get; set; }
        public double Armour { get; set; }
        public bool IsOverheated { get; set; }
        public IWeapon Weapon { get; set; }
        public double Cooldown { get; set; }
        public IAbility FireThrower { get; set; }
        public int Coins { get; set; }

        public Player(string name, IWeapon weapon)
        {
            Weapon = weapon;
            Name = name;
            Health = 100;
            Heat = 0;
            Armour = 0;
            IsOverheated = false;
            Cooldown = 20;
        }


        //Attackmethods
        public void QuickAttack(Player player)
        {
            Weapon.QuickAttack(player);
            Heat += 20;

            CheckIfPlayerIsOverheated();
        }

        public void NormalAttack(Player player)
        {
            Weapon.NormalAttack(player);
            Heat += 30;

            CheckIfPlayerIsOverheated();
        }

        public void HeavyAttack(Player player)
        {
            Weapon.HeavyAttack(player);
            Heat += 45;
        }

        //Abilities
        public void CastFireThrower(Player player)
        {
            FireThrower.Cast(player);
        }

        public void CastCoolDown()
        {
            if(Heat <= Cooldown)
            {
                Cooldown = 0;
                return;
            }

            Heat -= Cooldown;
            CheckIfPlayerIsOverheated();
        }

        //Checking
        private void CheckIfPlayerIsOverheated() {

            if(Heat >= 100)
            {
                IsOverheated = true;
            }

        }

    }
}
