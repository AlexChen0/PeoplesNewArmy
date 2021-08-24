using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    //this handles a single attacking option for a unit, given that the attacker is selected by the selection box
    //we attach this script to the button "attack" itself, so we need to first find the selectionbox and use its 
    //transform.position
    public GameObject Selectionbox;
    public PlayerUnitManager PUM; 
    public characteristics chara; 
    public EnemyCharacteristics enemyChara;
    public Vector2 coords = new Vector2(0,0);
    public int SI = 0;

    public PlayerUnit attackingUnit;
    public List<EnemyUnit> targetableEnemies;
    public List<EnemyUnit> allEnemies;

    public GameObject popUpBox;
    public Text target;
    public Animator animator;

    public int targetSelection;

    //Start is called before the first frame update
    void Start()
    {
        Selectionbox = GameObject.Find("Controller");
        PUM = GetComponent<PlayerUnitManager>();
        chara = GetComponent<characteristics>();
        enemyChara = GetComponent<EnemyCharacteristics>();

        for(int i = 0; i < PUM.PlayerUnits.Count; i++)
        {
            if(transform.position.x == PUM.PlayerUnits[i].transform.position.x 
            && transform.position.y == PUM.PlayerUnits[i].transform.position.y)
            {
                SI = i;
                testing = chara.getUnit(PUM.PlayerUnits[i].name);
                Debug.Log(testing.level);
                break;
            }
        }

        //now this can be used alongside characteristics
        attackingUnit = characteristics.getUnit(SI);
        
        var Enemydataset = Resources.Load<TextAsset>("Enemies");
        Debug.Log(Enemydataset);
        var lines = Enemydataset.text.Split('\n');

        var data = lines[targetline].Split('\t');
        var list = new List<string>(data); 

        //absolutely cursed programming LMAO 
        for(int i = 0; i < lines.Count; i++)
        {
            //this line does not work but we need it to so we need to figure out the workaround
            //lets change enemy and player to store their coordinates in the text file
            //should not be PUM. this is a fuckup.
            if(Mathf.Abs((PUM.EnemyUnits[i].xPos - PUM.PlayerUnits[selectionindex].transform.position.x) 
                            + PUM>EnemyUnits[i].yPos - PUM.PlayerUnits[selectionindex].transform.position.y) < attackingUnit.equipmentPointer)
            {
                //the 5.1 is not accurate. We should get a way to get range of the weapon held by the character
                targetableEnemies.Add(getEnemy(i))
            }
        }

        //all enemies targettable would be added. we need to wake up the combat UI now.
        popUpBox.SetActive(true);
        popUpBox.GetComponent<attackSelection>().enabled = true;
    }

}
