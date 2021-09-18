using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Data;

public class attackSelection : MonoBehaviour
{
    /*
    public GameObject Selectionbox;
    private PlayerUnitManager PUM; 
    private characteristics chara; 
    public EnemyCharacteristics enemyChara;
    public Vector2 coords = new Vector2(0,0);
    private int SI = 0;

    private PlayerUnit attackingUnit;
    private List<EnemyUnit> targetableEnemies;
    private List<EnemyUnit> allEnemies;
    */
    public GameObject AttackHandlerUI;
    public GameObject theEntireFuckingUI;

    public Text PlayerName;
    public Text target;
    public Text charaAttack;
    public Text charaHit;
    public Text charaCrit;
    public Text enemyAttack;
    public Text enemyHit;
    public Text enemyCrit;
    public Text charaWeapon;
    public Text enemyWeapon;

    public AttackHandler AH;
    public Weapons Wp;
    public AttackingScript AS;
    public EnemyStats estats;

    public int targetSelection = 0;
    public int weaponSelection = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("woke");
        AttackHandlerUI = GameObject.Find("AttackButton");
        theEntireFuckingUI = GameObject.Find("ActionSelection");
        Wp = GetComponent<Weapons>();
        AH = AttackHandlerUI.GetComponent<AttackHandler>();
        AS = GetComponent<AttackingScript>();
        //AttackHandlerUI.SetActive(false);
        theEntireFuckingUI.SetActive(false);
        this.PlayerName.text = AH.SI.ToString();
        var dataset = Resources.Load<TextAsset>("Equipment");
        //Debug.Log(dataset);
        var lines = dataset.text.Split('\n'); //splitting up into lines

        //int i = sprite that is specified in unity
        var data = lines[AH.attackingUnit.equipmentPointer].Split('\t');
        var list = new List<string>(data);
        updateStats();
    }
    // Update is called once per frame
    void Update()
    {
        //W and S will control enemy selection. A and D will control Weapon usage. 
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(targetSelection > 0)
                targetSelection--;
            else
                targetSelection = AH.targetableEnemies.Count - 1;
            estats = PUM.EnemyUnits[targetSelection].getComponent<EnemyStats>();
            updateStats();
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(targetSelection < AH.targetableEnemies.Count - 1)
                targetSelection++;
            else
                targetSelection = 0;
            estats = PUM.EnemyUnits[targetSelection].getComponent<EnemyStats>();
            updateStats();
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            weaponSelection = 0;

            updateStats();
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            weaponSelection = 3;

            updateStats();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            this.GetComponent<attackSelection>().enabled = false;
            AH.Selectionbox.GetComponent<MovementOfPieces>().canMove = true;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            var dataset = Resources.Load<TextAsset>("Equipment");
            var lines = dataset.text.Split('\n'); //splitting up into lines

            //int i = sprite that is specified in unity
            var data = lines[AH.attackingUnit.equipmentPointer].Split('\t');
            var list = new List<string>(data);

            //actually attack but this requires writing back to the resources so we fix errors now and come back later
            this.GetComponent<attackSelection>().enabled = false;
            AH.Selectionbox.GetComponent<MovementOfPieces>().canMove = true;

            //we now make the attack
            int hitrate = AS.PHitrate(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3])));
            bool itHit = UnityEngine.Random.Range(1, 100) < hitrate;

            if (itHit)
            {
                int healthAfterDamage = estats.health - AS.PAttackDamage(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3])));;

                /*
                //find the enemy to update
                var dat = Resources.Load<TextAsset>("Enemies");
                var rows = dat.text.Split('\n'); //splitting up into lines

                //write into file part
                //MenuItem("Tools/Write file")?
                string enemyFilePath = "Assets/Resources/test.txt";
                StreamWriter writer = new StreamWriter(enemyFilePath);

                writer.Write(rows[0]);

                for (int i = 1; i < rows.Length; i++) {
                    for (int j = 0; j < rows[0].Length - 1; j++) {
                        if (targetSelection + 1 == i && j == 1) {
                            writer.Write(healthAfterDamage.ToString());                              //new health value goes here!!!!!!!!!!!!!!!!!!!!!!!
                            writer.Write("\t");
                        } else {
                            writer.Write(rows[i][j]  + '\t');
                            //writer.Write('\t');
                        }
                    }
                    writer.WriteLine(rows[i][rows[0].Length - 1]);
                }

                writer.Close();
                */
                // version 2
                //we will not need this anymore, since we are now direct inserting damage into the estats
                /*    
                StreamReader streamreader = new StreamReader("Assets/Resources/Enemies.txt");
                string enemyFilePath = "Assets/Resources/test.txt";
                StreamWriter writer = new StreamWriter(enemyFilePath);
                char[] delimiter = new char[] { '\t' };
                //char tab = '\u0009';
                string[] stringDelimit = new string[] {"\t\t\t", "\t\t"};
                string[] columnheaders = streamreader.ReadLine().Split(delimiter);

                writer.WriteLine("Enemy	Level	Health	HPMax	Attack	Magic	Def	MDef	Speed	Stam	StmMax	Move	EquPtr");

                string line;
                int j = 1;
                while ((line = streamreader.ReadLine()) != null)
                {
                    string[] lin = line.Split(stringDelimit, StringSplitOptions.None);
                    string[] again = lin[0].Split(delimiter);
                    for (int i = 0; i < again.Length; i++) {
                        //lines[i] = lin[i].Replace(tab.ToString(), "");
                        if (i == 1 && j == targetSelection) {
                            writer.Write(healthAfterDamage.ToString());
                        } else if (i == again.Length - 1) {
                            writer.WriteLine(again[i]);
                        } else {
                            writer.Write(again[i] + '\t');
                        }
                    }
                    j++;
                }

                //write into file part
                //MenuItem("Tools/Write file")?

                writer.Close();
                */
                //instead we are replacing with the much easier (ideally)
                estats.health = healthAfterDamage;
                //we can implement death mechanics here
            }
            
        }

    }

    void updateStats()
    {
        var dataset = Resources.Load<TextAsset>("Equipment");
        //Debug.Log(dataset);
        var lines = dataset.text.Split('\n'); //splitting up into lines

        //int i = sprite that is specified in unity
        var data = lines[AH.attackingUnit.equipmentPointer].Split('\t');
        var list = new List<string>(data);
        this.target.text = targetSelection.ToString();
        this.charaAttack.text = AS.PAttackDamage(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.charaHit.text = AS.PHitrate(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.charaCrit.text = AS.PCritrate(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.enemyAttack.text = AS.EAttackDamage(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.enemyHit.text = AS.EHitrate(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.enemyCrit.text = AS.ECritrate(AH.pstats, estats, Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.charaWeapon.text = data[weaponSelection];
        this.enemyWeapon.text = data[weaponSelection];
    }
}
