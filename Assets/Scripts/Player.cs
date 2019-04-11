using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using MechAndSandals.Weapons;

namespace MechAndSandals
{
    public class Player : MonoBehaviour
    {
        public string Name { get; set; }
        public double Health { get; set; }
        //Heat represents mana, once a player overheats he cannot attack that turn
        public double Heat { get; set; }
        public double Armour { get; set; }
        public bool IsOverheated { get; set; }
        public List<IWeapon> Weapons { get; set; }
        public IWeapon SelectedWeapon { get; set; }
        public List<IAbility> Abilities { get; set; }
        public int Coins { get; set; }

        public void Update()
        {
            //Debug.Log(Heat);
        }

        public Player()
        {
            Weapons = new List<IWeapon>();
            Weapons.Add(new Gun(30, "GoodGun"));
            Weapons.Add(new Lazer(50, "GoodLaser"));
            Weapons.Add(new Missile(90, "GoodMissile"));
            Abilities = new List<IAbility>();
            Abilities.Add(new Abilities.FireThrower(100));
            Abilities.Add(new Abilities.Cooldown());
            Name = "Default player";
            Health = 100;
            Heat = 0;
            Armour = 50;
            IsOverheated = false;


        }
        public Player(string name, List<IWeapon> weaponList, List<IAbility> abilities)
        {
            Weapons = weaponList;
            Abilities = abilities;
            Name = name;
            Health = 100;
            Heat = 0;
            Armour = 0;
            IsOverheated = false;
        }


        //Attackmethods
        public void QuickAttack(Player player)
        {
            SelectedWeapon.QuickAttack(player);
            Heat += 20;

            CheckIfPlayerIsOverheated();
        }

        public void NormalAttack(Player player)
        {
            SelectedWeapon.NormalAttack(player);
            Heat += 30;

            CheckIfPlayerIsOverheated();
        }

        public void HeavyAttack(Player player)
        {
            SelectedWeapon.HeavyAttack(player);
            Heat += 45;

            CheckIfPlayerIsOverheated();
        }

        //Abilities
        public void CastAbility(Player player, IAbility ability)
        {
            ability.Cast(player);
            CheckCoolDown();
        }

        private void CheckCoolDown()
        {
            if(Heat < 0)
            {
                Heat = 0;
            }
        }

        //Checking
        private void CheckIfPlayerIsOverheated() {

            if(Heat >= 100)
            {
                IsOverheated = true;
            }
            else
            {
                IsOverheated = false;
            }
        }


    }
}
