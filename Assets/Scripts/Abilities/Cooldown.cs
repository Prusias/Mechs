using MechAndSandals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MechAndSandals.Abilities { 
    public class Cooldown : IAbility
    {
        private double cooldownVolune = 20;
        public string Name
        {
            get
            {
                return "Cooldown";
            }
        }

        public Cooldown()
        {
            cooldownVolune = 20;
        }

        public Cooldown(int value)
        {
            cooldownVolune = value;
        }

        public void Cast(Player player)
        {
            player.Heat -= cooldownVolune; 
        }

        public void UpdateDamage(double damageToBeAddedOrSubtracted)
        {
            cooldownVolune += damageToBeAddedOrSubtracted;
        }
    }

}
