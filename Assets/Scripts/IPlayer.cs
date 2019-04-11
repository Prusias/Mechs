using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MechAndSandals
{
    public interface IPlayer
    {
        string Name { get; set; }
        double Health { get; set; }
        //Heat represents mana, once a player overheats he cannot attack that turn
        double Heat { get; set; }
        double Armour { get; set; }
        bool IsOverheated { get; set; }
    }
}
