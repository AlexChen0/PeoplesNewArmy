using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class EnemyCharacteristics : MonoBehaviour
{
    //if you want to see comments go to the characteristics doc lol
    private int maxEquipmentNum;
    private int[] power = new int[3];
    private int[] accuracy = new int[3];
    private int[] sharpness = new int[3];

    public EnemyUnit getEnemy(string name)
    {
        var dataset = Resources.Load<TextAsset>("Enemies");
        Debug.Log(dataset);
        var lines = dataset.text.Split('\n'); //splitting up into lines

        //int i = sprite that is specified in unity
        EnemyUnit targetEnemy;
        int targetline = -1;
        for(int i = 0; i < lines.Length; i++)
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
            Debug.Log("Error: invalid Enemy");
            throw new InvalidOperationException("Enemy does not exist");
        }
        else
        {
            var data = lines[targetline].Split('\t'); //i will be the line the selected sprite is specified
            var list = new List<string>(data); //make a List with the sprites stats
            targetEnemy.level = Convert.ToInt32(list[1]);
            targetEnemy.health = Convert.ToInt32(list[2]);
            targetEnemy.maxHealth = Convert.ToInt32(list[3]);
            targetEnemy.pAttack = Convert.ToInt32(list[4]);
            targetEnemy.mAttack = Convert.ToInt32(list[5]);
            targetEnemy.pDefense = Convert.ToInt32(list[6]);
            targetEnemy.mDefense = Convert.ToInt32(list[7]);
            targetEnemy.speed = Convert.ToInt32(list[8]);
            targetEnemy.stamina = Convert.ToInt32(list[9]);
            targetEnemy.maxStamina = Convert.ToInt32(list[10]);
            targetEnemy.movement = Convert.ToInt32(list[11]);
            targetEnemy.equipmentPointer = Convert.ToInt32(list[12]);
            return targetEnemy;
        }
        
    }

}
public struct EnemyUnit
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
    //enemy invisible stats
    public int equipmentPointer;

}
/*
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
        
    }
}
*/