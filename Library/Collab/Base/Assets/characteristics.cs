using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class characteristics : MonoBehaviour
{
    //unit stats - should these be private and make get/set methods to change them? can scripts call eachother like that?
    private int level;
    private int health;
    private int maxHealth;
    private int pAttack;
    private int mAttack;
    private int pDefense;
    private int mDefense;
    private int speed;
    private int stamina;
    private int maxStamina;
    private int movement;

    //unit invisible stats
    private int unitPriorityModifier;
    private int equipmentPointer;
    private int[] growthRates;
    private int[] skills = new int[10]; //0th spot in the array is ___, 1st spot is ___, etc

    //equipment stats
    private int maxEquipmentNum;
    private int[] power = new int[3];
    private int[] accuracy = new int[3];
    private int[] sharpness = new int[3];
    //private Weapon[] weapons = new Weapon[3];

    // Start is called before the first frame update
    void Start()
    {
        //find stats from the characteristics.csv file
        /*
        var fileData : String  = System.IO.File.ReadAllText(path);
        var lines : String[] = fileData.Split("\n"[0]);
        var lineData : String[] = (lines[0].Trim()).Split(","[0]);
        */
        
        //string path = "Assets/PlayerCharacter.txt";
        //AssetDatabase.ImportAsset(path);
        //TextAsset dataset = Resources.Load("PlayerCharacter");        
        var dataset = Resources.Load<TextAsset>("PlayerCharacter"); 
        Debug.Log(dataset);
        var lines = dataset.text.Split('\n'); //splitting up into lines

        //int i = sprite that is specified in unity

        var data = lines[1].Split('\t'); //i will be the line the selected sprite is specified
        var list = new List<string>(data); //make a List with the sprites stats
        
        level = Convert.ToInt32(list[0]);
        Debug.Log(level);
        health = Convert.ToInt32(list[1]);
        maxHealth = Convert.ToInt32(list[2]);
        pAttack = Convert.ToInt32(list[3]);
        mAttack = Convert.ToInt32(list[4]);
        pDefense = Convert.ToInt32(list[5]);
        mDefense = Convert.ToInt32(list[6]);
        speed = Convert.ToInt32(list[7]);
        stamina = Convert.ToInt32(list[8]);
        maxStamina = Convert.ToInt32(list[9]);
        movement = Convert.ToInt32(list[10]);
        maxEquipmentNum = Convert.ToInt32(list[11]);
        //etc

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Weapons
{
    public enum Weapon {sword, spear, potato};
    //private int sharpness; //does this need to go here or will this go into the characteristics file?
    //public Weapon selection;

    static void Main(string[] args) {
        //https://www.studica.com/blog/unity-tutorial-how-to-use-enums

        Weapons myWeapon = new Weapons();
        //selection = getinput from somewhere

        //set selection from user
        /*
        switch (selection)
        {
            case Weapon.sword:
                Debug.Log("sword");
                //enter stats for the weapon
                break;
            
            case Weapon.spear:
                Debug.Log("spear");
                break;
            
            case Weapon.potato:
                Debug.Log("potato");
                break;

            default:
                Debug.Log("ya goofed");
                break;
        }
        */
    }
}