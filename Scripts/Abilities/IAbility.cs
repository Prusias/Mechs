using System;
using System.Collections.Generic;
using System.Text;

namespace MechAndSandals
{
    public interface IAbility
    {
        void Cast(Player player);
        void UpdateDamage(double damageToBeAddedOrSubtracted);
    }
}
