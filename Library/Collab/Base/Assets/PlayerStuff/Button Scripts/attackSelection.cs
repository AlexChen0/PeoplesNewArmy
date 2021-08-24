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

            updateStats();
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(targetSelection < AH.targetableEnemies.Count - 1)
                targetSelection++;
            else
                targetSelection = 0;

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
            //actually attack but this requires writing back to the resources so we fix errors now and come back later
            this.GetComponent<attackSelection>().enabled = false;
            AH.Selectionbox.GetComponent<MovementOfPieces>().canMove = true;
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
        this.charaAttack.text = AS.PAttackDamage(AH.attackingUnit, AH.targetableEnemies[targetSelection], Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.charaHit.text = AS.PHitrate(AH.attackingUnit, AH.targetableEnemies[targetSelection], Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.charaCrit.text = AS.PCritrate(AH.attackingUnit, AH.targetableEnemies[targetSelection], Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.enemyAttack.text = AS.EAttackDamage(AH.attackingUnit, AH.targetableEnemies[targetSelection], Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.enemyHit.text = AS.EHitrate(AH.attackingUnit, AH.targetableEnemies[targetSelection], Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.enemyCrit.text = AS.ECritrate(AH.attackingUnit, AH.targetableEnemies[targetSelection], Wp.setWeapon(data[weaponSelection + 1], data[weaponSelection + 2], Convert.ToInt32(data[weaponSelection + 3]))).ToString();
        this.charaWeapon.text = data[weaponSelection];
        this.enemyWeapon.text = data[weaponSelection];

        //find the enemy to update
        var dat = Resources.Load<TextAsset>("Enemies");
        var rows = dataset.text.Split('\n'); //splitting up into lines

        lines[targetSelection + 1][1] = "0";

        //write into file part
        //MenuItem("Tools/Write file")?
        string enemyFilePath = "Assets/Resources/Enemies.txt";
        StreamWriter writer = new StreamWriter(enemyFilePath);

        for (int i = 0; i < rows.Length; i++) {
            for (int j = 0; j < rows[0].Length - 1; j++) {}
                writer.Write(rows[i][j]);
                writer.Write('\t');
            }
            writer.WriteLine(rows[i][rows[0].Length]);
        }

        writer.Close();
    }
}
