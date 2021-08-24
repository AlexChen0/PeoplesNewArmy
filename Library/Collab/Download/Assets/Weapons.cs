using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    enum weaponType {sword, spear, axe, bow, knife, potato};
    enum weaponMaterial {iron, steel, starch}; 

    private int sharpness; //does this need to go here or will this go into the characteristics file?
    //good question I'm thinking that if we have weapons as a struct then it just becomes like an int 
    //that it holds with a floor of -5 and ceiling of 5

    struct Weapon{

        public weaponType type;
        public weaponMaterial material;
        public int sharpness;

        public Weapon(weaponType wT, weaponMaterial wM, int s)
        {
            this.type = wT;
            this.material = wM;
            this.sharpness = s;
        }
    }
}