using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttackHandler : MonoBehaviour
{
    //this handles a single attacking option for a unit, given that the attacker is selected by the selection box
    //we attach this script to the button "attack" itself, so we need to first find the selectionbox and use its 
    //transform.position
    public GameObject Selectionbox;
    public PlayerUnitManager PUM; 
    public PlayerStats pstats; 
    //estats is not needed here, but will be needed in attackselection
    //public EnemyStats estats;
    public Vector2 coords = new Vector2(0,0);
    public int SI = 0;
    public List<EnemyUnit> targetableEnemies = new List<EnemyUnit>();

    public GameObject popUpBox;

    public int targetSelection;

    //Start is called before the first frame update
    public void ButtonClicked()
    {
        Debug.Log("AttackHandler was called!");
        Selectionbox = GameObject.Find("Controller");
        PUM = Selectionbox.GetComponent<PlayerUnitManager>();

        for(int i = 0; i < PUM.PlayerUnits.Count; i++)
        {
            if(Selectionbox.transform.position.x == PUM.PlayerUnits[i].transform.position.x 
            && Selectionbox.transform.position.y == PUM.PlayerUnits[i].transform.position.y)
            {
                SI = i;
                //pstats we will find the closest gameobject to the selectionbox, and then use that
                pstats = PUM.PlayerUnits[i].GetComponent<PlayerStats>();
                break;
            }
        }
        //now this can be used alongside characteristics
        
        var Enemydataset = Resources.Load<TextAsset>("Enemies");
        var lines = Enemydataset.text.Split('\n');

        var data = lines[SI].Split('\t');
        var list = new List<string>(data); 

        //absolutely cursed programming LMAO 
        for(int i = 0; i < PUM.enemyUnits.Count; i++)
        {
            //this line does not work but we need it to so we need to figure out the workaround
            //lets change enemy and player to store their coordinates in the text file
            //should not be PUM. this is a fuckup.
            if(Mathf.Abs((PUM.enemyUnits[i].transform.position.x - PUM.PlayerUnits[SI].transform.position.x) 
                            + (PUM.enemyUnits[i].transform.position.y - PUM.PlayerUnits[SI].transform.position.y)) < attackingUnit.equipmentPointer)
            {
                //the 5.1 is not accurate. We should get a way to get range of the weapon held by the character
                targetableEnemies.Add(enemyChara.getEnemy(i));
            }
        }

        //all enemies targettable would be added. we need to wake up the combat UI now.
        popUpBox.SetActive(true);
        //popUpBox.GetComponent<attackSelection>().enabled = true;
    }

}
