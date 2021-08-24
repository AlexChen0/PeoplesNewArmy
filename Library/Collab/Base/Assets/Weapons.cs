using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public class Weapon{
        enum weapon {sword, spear, potato};
        private int sharpness; //does this need to go here or will this go into the characteristics file?

        public Weapon(Weapon weapon, int sharpness) {

            this.weapon = weapon;
            this.sharpness = sharpness;
        }

        public Weapon() {
            this.weapon = weapon.potato;
            this.sharpness = 0;
        }



        
        public Weapon getWeapon(Weapon weapon) {
        //https://www.studica.com/blog/unity-tutorial-how-to-use-enums

        Weapon myWeapon = new Weapon();
        //selection = getinput from somewhere
        
        /*
        switch (weapon)
        {
            case Weapon.sword:
                Debug.Log("sword");
                //enter stats for the weapon
                return w;
                break;
            
            case Weapon.spear:
                Debug.Log("spear");
                return w;
                break;
            
            case Weapon.potato:
                Debug.Log("potato");
                return w;
                break;

            default:
                Debug.Log("ya goofed");
                return w;
                break;
        }
        */
        return myWeapon;
        }



        public int getSharpness(int selection) {
            //do we want methods like this where we have a base sharpness here or keep it in the characteristic file?
            return 0;
        }
    }
}
