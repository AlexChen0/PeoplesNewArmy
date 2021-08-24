using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public string enemyName;
    public int level;
    public int health;
    public int MaxHealth;
    public int attack;
    public int magic;
    public int defense;
    public int magicdefense;
    public int speed;
    public int stamina;
    public int maxstamina;
    public int move;
    public int equipment; //similiar idea here, will need to replace with a struct that describes equipment
    public int hasmoved;
    // Start is called before the first frame update
    void Start()
    {
        enemyName = gameObject.name;
        var dataset = Resources.Load<TextAsset>("Enemies");
        var lines = dataset.text.Split('\n'); //splitting up into lines

        int targetline = -1;
        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split('\t');
            var list = new List<string>(data);
            if (Equals(list[0].ToString(), enemyName))
            {
                Debug.Log("target found");
                targetline = i;
                break;
            }
        }
        if (targetline == -1)
        {
            Debug.Log("Error: invalid Enemy");
            throw new InvalidOperationException("Enemy does not exist");
        }
        else
        {
            var data = lines[targetline].Split('\t'); //i will be the line the selected sprite is specified
            var list = new List<string>(data); //make a List with the sprites stats
            level = Convert.ToInt32(list[1]);
            health = Convert.ToInt32(list[2]);
            maxHealth = Convert.ToInt32(list[3]);
            attack = Convert.ToInt32(list[4]);
            magic = Convert.ToInt32(list[5]);
            defense = Convert.ToInt32(list[6]);
            magicDefense = Convert.ToInt32(list[7]);
            speed = Convert.ToInt32(list[8]);
            stamina = Convert.ToInt32(list[9]);
            maxStamina = Convert.ToInt32(list[10]);
            move = Convert.ToInt32(list[11]);
            equipment = Convert.ToInt32(list[12]);
            hasMoved = Convert.ToInt32(list[13]);
        }
    }

    void OnAppliationQuit()
    {
        StreamReader streamreader = new StreamReader("Assets/Resources/Enemies.txt");
                string PlayerFilePath = "Assets/Resources/test.txt";
                StreamWriter writer = new StreamWriter(PlayerFilePath);
                char[] delimiter = new char[] { '\t' };
                //char tab = '\u0009';
                string[] stringDelimit = new string[] {"\t\t\t", "\t\t"};
                string[] columnheaders = streamreader.ReadLine().Split(delimiter);

                string line;
                int j = 1;
                while ((line = streamreader.ReadLine()) != null)
                {
                    string[] lin = line.Split(stringDelimit, StringSplitOptions.None);
                    string[] again = lin[0].Split(delimiter);
                    for (int i = 0; i < again.Length; i++) {
                        for(int j = 0; j < 14; j++) //14 is a hard coded value for the variable count. 
                        {
                            if(again[0] == playerName)
                            {
                                //we have found the line we save at.
                                writer.Write(playerName + '\t');
                                writer.Write(level + '\t');
                                writer.Write(health + '\t');
                                writer.Write(maxHealth + '\t');
                                writer.Write(attack + '\t');
                                writer.Write(magic + '\t');
                                writer.Write(defense + '\t');
                                writer.Write(magicDefense + '\t');
                                writer.Write(speed + '\t');
                                writer.Write(stamina + '\t');
                                writer.Write(maxStamina + '\t');
                                writer.Write(move + '\t');
                                writer.Write(priorityModifier + '\t');
                                writer.Write(equipment + '\t');
                                writer.Write(hasMoved + '\t');
                            }
                        }
                    }
                }

                //write into file part
                //MenuItem("Tools/Write file")?

                writer.Close();
    }
}
