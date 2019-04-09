using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals
{
    public interface IAbility { 
        
        string Name { get; }
        void Cast(Player player);
        void UpdateDamage(double damageToBeAddedOrSubtracted);
    }
}
