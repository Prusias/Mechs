using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals
{
    public class AIPlayer
    {
        public string Name { get; set; }
        public double Health { get; set; }
        //Heat represents mana, once a player overheats he cannot attack that turn
        public double Heat { get; set; }
        public double Armour { get; set; }
        public bool IsOverheated { get; set; }
        public List<IWeapon> Weapons { get; set; }
        public IWeapon SelectedWeapon { get; set; }
        public double Cooldown { get; set; }
        public IAbility FireThrower { get; set; }
        public string[] DifficultyList = { "Easy", "Medium", "Hard", "Insane", "Ely" };
        public int ChosenDifficulty { get; set; }


        public AIPlayer(List<IWeapon> weaponList, int difficulty)
        {

            ChosenDifficulty = difficulty;
            Weapons = weaponList;
            Name = "CPU";
            Health = 100;
            Heat = 0;
            IsOverheated = false;

            if (ChosenDifficulty == 0)
            {
                Armour = 0;
                Cooldown = 10;
            }
            if (ChosenDifficulty == 1)
            {
                Armour = 30;
                Cooldown = 20;
            }
            if (ChosenDifficulty == 2)
            {
                Armour = 60;
                Cooldown = 25;
            }
            if (ChosenDifficulty == 3)
            {
                Armour = 90;
                Cooldown = 30;
            }
            if (ChosenDifficulty == 4)
            {
                Armour = 120;
                Cooldown = 35;
            }
        }



        public void GenerateAttack(Player p)
        {
            //random cooldown possibility
            bool RandomCooldown = false;
            bool RandomAttack = false;
            Random r = new Random();
            //randomise chance to have random cooldown
            int ratio = r.Next(10);
            if(ratio > 7)
            {
                RandomCooldown = true;
            }
            ratio = r.Next(10);
            if (ratio > 7)
            {
                RandomAttack = true;
            }


            //do random cooldown if true 
            if (RandomCooldown == true)
            {
                CastCoolDown();
            }
            else if (RandomCooldown == false && RandomAttack == true)
            {
                //if random attack is true generate a random attack
                bool possible = false;
                while(!possible)
                {
                    ratio = r.Next(20);
                    if (ratio >= 16)
                    {
                        if(Heat <=55)
                        {
                            HeavyAttack(p);
                            possible = true;
                        }
                    }
                    else if (ratio <= 15 && ratio >= 10)
                    {
                        if (Heat <= 70)
                        {
                            NormalAttack(p);
                            possible = true;
                        }
                    }
                    else if (ratio <= 9 && ratio >= 5)
                    {
                        if (Heat <= 55)
                        {
                            QuickAttack(p);
                            possible = true;
                        }
                    }
                    else if (ratio <= 4 && ratio >= 0)
                    {
                        if (Heat <= 75)
                        {
                            CastFireThrower(p);
                            possible = true;
                        }
                    }
                }              
            }
            else
            {
                //choosing what attack to do based on heat that's left
                if (Heat >= 0 && Heat <= 55)
                {
                    HeavyAttack(p);
                }
                else if (Heat >= 0 && Heat <= 70)
                {
                    NormalAttack(p);
                }
                else if (Heat >= 0 && Heat <= 80)
                {
                    QuickAttack(p);
                }
                else
                {
                    CastCoolDown();
                }
            }
        }

        public void CastCoolDown()
        {
            if (Heat <= Cooldown)
            {
                Cooldown = 0;
            }
            else
            {
                Heat -= Cooldown;
            }
        }

        public void QuickAttack(Player player)
        {
            SelectedWeapon.QuickAttack(player);
            Heat += 20;
        }

        public void NormalAttack(Player player)
        {
            SelectedWeapon.NormalAttack(player);
            Heat += 30;
        }

        public void HeavyAttack(Player player)
        {
            SelectedWeapon.HeavyAttack(player);
            Heat += 45;
        }

        public void CastFireThrower(Player player)
        {
            FireThrower.Cast(player);
            Heat += 20;
        }
    }
}