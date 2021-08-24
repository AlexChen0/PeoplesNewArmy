using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapons : MonoBehaviour
{
    public enum weaponType {sword, spear, axe, bow, knife, potato};
    public enum weaponMaterial {iron, steel, silver, mithril, adamantine, draconic, obsidian, darkstone, starch}; 

    public int sharpness; //does this need to go here or will this go into the characteristics file?
    //good question I'm thinking that if we have weapons as a struct then it just becomes like an int 
    //that it holds with a floor of -5 and ceiling of 5
    float baseval;
    float matmod;
    float sharpmod;
    public struct Weapon{

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

    public Weapon setWeapon(string a, string b, int c)
    {
        weaponType type = weaponType.potato;
        if(String.Equals(a, "sword")) {
            type = weaponType.sword;
        } else if (String.Equals(a, "spear")) {
            type = weaponType.spear;
        } else if (String.Equals(a, "axe")) {
            type = weaponType.axe;
        } else if (String.Equals(a, "bow")) {
            type = weaponType.bow;
        } else if (String.Equals(a, "knife")) {
            type = weaponType.knife;
        } else if (String.Equals(a, "potato")) {
            type = weaponType.potato;
        }
        weaponMaterial mat = weaponMaterial.starch;
        if(String.Equals(b, "iron")) {
            mat = weaponMaterial.iron;
        }  else if (String.Equals(b, "steel")) {
            mat = weaponMaterial.steel;
        } else if (String.Equals(b, "starch")) {
            mat = weaponMaterial.starch;
        }
        return new Weapon(type, mat, c);

    }

    public int getBaseHitrate(Weapon weapon)
    {
        switch(weapon.type)
        {
            case weaponType.sword:
                baseval = 80f;
                break;
            case weaponType.spear:
                baseval = 70f;
                break;
            case weaponType.axe:
                baseval = 60f;
                break;
            case weaponType.bow:
                baseval = 60f;
                break;
            case weaponType.knife:
                baseval = 80f;
                break;
            case weaponType.potato:
                baseval = 90f;
                break;
            default:
                baseval = 0f;
                break;
            

        }
        switch(weapon.material)
        {
            case weaponMaterial.iron:
                matmod = 1f;
                break;
            case weaponMaterial.steel:
                matmod = 1f;
                break;
            case weaponMaterial.silver:
                matmod = 1f;
                break;
            case weaponMaterial.mithril:
                matmod = 1.05f;
                break;
            case weaponMaterial.adamantine:
                matmod = 1f;
                break;
            case weaponMaterial.draconic:
                matmod = 1.1f;
                break;
            case weaponMaterial.obsidian:
                matmod = 1f;
                break;
            case weaponMaterial.darkstone:
                matmod = 1.05f;
                break;
            default:
                matmod = 0f;
                break;
        }
        switch(weapon.sharpness)
        {
            case 5:
                sharpmod = 1.1f;
                break;
            case 4:
                sharpmod = 1.1f;
                break;
            case 3:
                sharpmod = 1.1f;
                break;
            case 2:
                sharpmod = 1.1f;
                break;
            case 1:
                sharpmod = 1.05f;
                break;
            case 0:
                sharpmod = 1f;
                break;
            case -1:
                sharpmod = 1f;
                break;
            case -2:
                sharpmod = .9f;
                break;
            case -3:
                sharpmod = .8f;
                break;
            case -4:
                sharpmod = .6f;
                break;
            case -5:
                sharpmod = .3f;
                break;
            default:
                sharpmod = 0f;
                break;

        }
        return (int) (baseval * matmod * sharpmod);
    }

    public int getBaseAttack(Weapon weapon)
    {
        switch(weapon.type)
        {
            case weaponType.sword:
                baseval = 7f;
                break;
            case weaponType.spear:
                baseval = 7f;
                break;
            case weaponType.axe:
                baseval = 10f;
                break;
            case weaponType.bow:
                baseval = 2f;
                break;
            case weaponType.knife:
                baseval = 1f;
                break;
            case weaponType.potato:
                baseval = 40f;
                break;
            default:
                baseval = 0f;
                break;
            

        }
        switch(weapon.material)
        {
            case weaponMaterial.iron:
                matmod = 1f;
                break;
            case weaponMaterial.steel:
                matmod = 1.2f;
                break;
            case weaponMaterial.silver:
                matmod = 1.4f;
                break;
            case weaponMaterial.mithril:
                matmod = 1.4f;
                break;
            case weaponMaterial.adamantine:
                matmod = 1.5f;
                break;
            case weaponMaterial.draconic:
                matmod = 1.6f;
                break;
            case weaponMaterial.obsidian:
                matmod = 1.75f;
                break;
            case weaponMaterial.darkstone:
                matmod = 1.35f;
                break;
            default:
                matmod = 0f;
                break;
        }
        switch(weapon.sharpness)
        {
            case 5:
                sharpmod = 1.33f;
                break;
            case 4:
                sharpmod = 1.3f;
                break;
            case 3:
                sharpmod = 1.25f;
                break;
            case 2:
                sharpmod = 1.20f;
                break;
            case 1:
                sharpmod = 1.10f;
                break;
            case 0:
                sharpmod = 1f;
                break;
            case -1:
                sharpmod = .95f;
                break;
            case -2:
                sharpmod = .9f;
                break;
            case -3:
                sharpmod = .8f;
                break;
            case -4:
                sharpmod = .6f;
                break;
            case -5:
                sharpmod = .3f;
                break;
            default:
                sharpmod = 0f;
                break;

        }
        return (int) (baseval * matmod * sharpmod);
    }

    public int getBaseCritrate(Weapon weapon)
    {
        return 10;
    }

    public int getWeight(Weapon weapon)
    {
        switch(weapon.type)
        {
            case weaponType.sword:
                baseval = 5f;
                break;
            case weaponType.spear:
                baseval = 6f;
                break;
            case weaponType.axe:
                baseval = 10f;
                break;
            case weaponType.bow:
                baseval = 6f;
                break;
            case weaponType.knife:
                baseval = 1f;
                break;
            case weaponType.potato:
                baseval = 7f;
                break;
            default:
                baseval = 0f;
                break;
            

        }
        switch(weapon.material)
        {
            case weaponMaterial.iron:
                matmod = 1f;
                break;
            case weaponMaterial.steel:
                matmod = 1f;
                break;
            case weaponMaterial.silver:
                matmod = 1f;
                break;
            case weaponMaterial.mithril:
                matmod = .9f;
                break;
            case weaponMaterial.adamantine:
                matmod = 1.2f;
                break;
            case weaponMaterial.draconic:
                matmod = .9f;
                break;
            case weaponMaterial.obsidian:
                matmod = 1f;
                break;
            case weaponMaterial.darkstone:
                matmod = 1.3f;
                break;
            default:
                matmod = 0f;
                break;
        }
        return (int) (baseval * matmod);
    }
}