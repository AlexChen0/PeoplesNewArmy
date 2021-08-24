using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
//using Weapons; //something about static classes
using System.Data;

public class characteristics : MonoBehaviour
{
    /*
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
    */
    //equipment stats
    private int maxEquipmentNum;
    private int[] power = new int[3];
    private int[] accuracy = new int[3];
    private int[] sharpness = new int[3];
    //private Weapon[] weapons = new Weapon[3];

    // Start is called before the first frame update
    void Start()
    {
        /*
        //find stats from the characteristics.csv file
        var fileData : String  = System.IO.File.ReadAllText(path);
        var lines : String[] = fileData.Split("\n"[0]);
        var lineData : String[] = (lines[0].Trim()).Split(","[0]);
        
        
        //string path = "Assets/PlayerCharacter.txt";
        //AssetDatabase.ImportAsset(path);
        //TextAsset dataset = Resources.Load("PlayerCharacter");        
        var dataset = Resources.Load<TextAsset>("PlayerCharacter");
        Debug.Log(dataset);
        var lines = dataset.text.Split('\n'); //splitting up into lines

        //int i = sprite that is specified in unity

        var data = lines[1].Split('\t'); //i will be the line the selected sprite is specified
        var list = new List<string>(data); //make a List with the sprites stats
        Debug.Log(list);
        
        Debug.Log(list[0]);
        level = Convert.ToInt32(list[1]);
        Debug.Log(level);
        health = Convert.ToInt32(list[2]);
        maxHealth = Convert.ToInt32(list[3]);
        pAttack = Convert.ToInt32(list[4]);
        mAttack = Convert.ToInt32(list[5]);
        pDefense = Convert.ToInt32(list[6]);
        mDefense = Convert.ToInt32(list[7]);
        speed = Convert.ToInt32(list[8]);
        stamina = Convert.ToInt32(list[9]);
        maxStamina = Convert.ToInt32(list[10]);
        movement = Convert.ToInt32(list[11]);
        maxEquipmentNum = Convert.ToInt32(list[12]);
        //etc
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerUnit getUnit(string name)
    {
        var dataset = Resources.Load<TextAsset>("PlayerCharacter");
        var lines = dataset.text.Split('\n'); //splitting up into lines

        //int i = sprite that is specified in unity
        PlayerUnit targetPlayer;
        int targetline = -1;
        for(int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split('\t');
            var list = new List<string>(data);
            if(Equals(list[0].ToString(), name))
            {
                Debug.Log("target found");
                targetline = i;
                break;
            }
        }
        if(targetline == -1)
        {
            Debug.Log("Error: invalid player");
            throw new InvalidOperationException("Player does not exist");
        }
        else
        {
            var data = lines[targetline].Split('\t'); //i will be the line the selected sprite is specified
            var list = new List<string>(data); //make a List with the sprites stats
            targetPlayer.level = Convert.ToInt32(list[1]);
            targetPlayer.health = Convert.ToInt32(list[2]);
            targetPlayer.maxHealth = Convert.ToInt32(list[3]);
            targetPlayer.pAttack = Convert.ToInt32(list[4]);
            targetPlayer.mAttack = Convert.ToInt32(list[5]);
            targetPlayer.pDefense = Convert.ToInt32(list[6]);
            targetPlayer.mDefense = Convert.ToInt32(list[7]);
            targetPlayer.speed = Convert.ToInt32(list[8]);
            targetPlayer.stamina = Convert.ToInt32(list[9]);
            targetPlayer.maxStamina = Convert.ToInt32(list[10]);
            targetPlayer.movement = Convert.ToInt32(list[11]);
            targetPlayer.unitPriorityModifier = Convert.ToInt32(list[12]);
            targetPlayer.equipmentPointer = Convert.ToInt32(list[13]);
            targetPlayer.healthGrowth = Convert.ToInt32(list[14]);
            targetPlayer.attackGrowth = Convert.ToInt32(list[15]);
            targetPlayer.magicGrowth = Convert.ToInt32(list[16]);
            targetPlayer.defenseGrowth = Convert.ToInt32(list[17]);
            targetPlayer.mdefenseGrowth = Convert.ToInt32(list[18]);
            targetPlayer.speedGrowth = Convert.ToInt32(list[19]);
            targetPlayer.staminaGrowth = Convert.ToInt32(list[20]);
            targetPlayer.availability = Convert.ToInt32(list[21]);
            return targetPlayer;
        }
        
    }

    public PlayerUnit getUnit(int index)
    {
        var dataset = Resources.Load<TextAsset>("PlayerCharacter");
        var lines = dataset.text.Split('\n'); //splitting up into lines

        //int i = sprite that is specified in unity
        PlayerUnit targetPlayer;
        int targetline = -1;
        for(int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split('\t');
            var list = new List<string>(data);
            if(index + 1 == i)
            {
                Debug.Log("target found");
                targetline = i;
                break;
            }
        }
        if(targetline == -1)
        {
            Debug.Log("Error: invalid player");
            throw new InvalidOperationException("Player does not exist");
        }
        else
        {
            var data = lines[targetline].Split('\t'); //i will be the line the selected sprite is specified
            var list = new List<string>(data); //make a List with the sprites stats
            targetPlayer.level = Convert.ToInt32(list[1]);
            targetPlayer.health = Convert.ToInt32(list[2]);
            targetPlayer.maxHealth = Convert.ToInt32(list[3]);
            targetPlayer.pAttack = Convert.ToInt32(list[4]);
            targetPlayer.mAttack = Convert.ToInt32(list[5]);
            targetPlayer.pDefense = Convert.ToInt32(list[6]);
            targetPlayer.mDefense = Convert.ToInt32(list[7]);
            targetPlayer.speed = Convert.ToInt32(list[8]);
            targetPlayer.stamina = Convert.ToInt32(list[9]);
            targetPlayer.maxStamina = Convert.ToInt32(list[10]);
            targetPlayer.movement = Convert.ToInt32(list[11]);
            targetPlayer.unitPriorityModifier = Convert.ToInt32(list[12]);
            targetPlayer.equipmentPointer = Convert.ToInt32(list[13]);
            targetPlayer.healthGrowth = Convert.ToInt32(list[14]);
            targetPlayer.attackGrowth = Convert.ToInt32(list[15]);
            targetPlayer.magicGrowth = Convert.ToInt32(list[16]);
            targetPlayer.defenseGrowth = Convert.ToInt32(list[17]);
            targetPlayer.mdefenseGrowth = Convert.ToInt32(list[18]);
            targetPlayer.speedGrowth = Convert.ToInt32(list[19]);
            targetPlayer.staminaGrowth = Convert.ToInt32(list[20]);
            targetPlayer.availability = Convert.ToInt32(list[21]);
            return targetPlayer;
        }
        
    }
}
public struct PlayerUnit
{
    public int level;
    public int health;
    public int maxHealth;
    public int pAttack;
    public int mAttack;
    public int pDefense;
    public int mDefense;
    public int speed;
    public int stamina;
    public int maxStamina;
    public int movement;
    //unit invisible stats
    public int unitPriorityModifier;
    public int equipmentPointer;
    public int healthGrowth;
    public int attackGrowth;
    public int magicGrowth;
    public int defenseGrowth;
    public int mdefenseGrowth;
    public int speedGrowth;
    public int staminaGrowth;
    public int availability;
}