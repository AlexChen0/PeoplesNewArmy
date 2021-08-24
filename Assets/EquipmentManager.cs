using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    //we may need a txt file that gives a player's equipment stats, this is something we will need to figure out soon
    enum Item {StatBoost, Healing, None}; 
    enum Offhand {Shield, Knife, None};
    struct EquipmentPage
    {
        public Weapons.Weapon weapon1;
        public Weapons.Weapon weapon2;
        public Offhand OffHand;
        public Item item1;
        public Item item2;

        public EquipmentPage(Weapons.Weapon w1, Weapons.Weapon w2, Offhand OH, Item i1, Item i2)
        {
            this.weapon1 = w1;
            this.weapon2 = w2;
            this.OffHand = OH;
            this.item1 = i1;
            this.item2 = i2;
        }

    }
}
