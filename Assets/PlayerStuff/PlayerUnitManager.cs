using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using characteristics; gonna be a pain with static and stuff

public class PlayerUnitManager : MonoBehaviour
{

    bool timeToDoAction; //flag
    enum actionType {physical, magical, heal, rally, item, nothing, error};
    public List<GameObject> PlayerUnits = new List<GameObject>();
    public List<GameObject> enemyUnits = new List<GameObject>();
    actionType currentAction = actionType.error;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.GameObject[] GOPlayerUnits;
        GOPlayerUnits = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject i in GOPlayerUnits)
        {
            PlayerUnits.Add(i);
        }
        
        UnityEngine.GameObject[] GOEnemyUnits;
        GOEnemyUnits = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject i in GOEnemyUnits)
        {
            enemyUnits.Add(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToDoAction) {

            //get action from player (from movement of pieces?)
            //get which piece is doing action and which piece is affected by action;
            int unitID = 0; //GameObject.find...... or get it from the list by iterating through it
            int enemyID = 0; //same
            int targetID = 0;
            switch (currentAction)
            {
                case actionType.physical:
                    dealPhysicalDamage(unitID, enemyID);
                    break;
                case actionType.magical:
                    dealMagicDamage(unitID, enemyID);
                    break;
                case actionType.heal:
                    heal(unitID, targetID);
                    break;
                case actionType.rally:
                    rally(unitID, targetID);
                    break;
                case actionType.item:
                    useItem(unitID);
                    break;
                case actionType.nothing:
                    doNothing(unitID);
                    break;
                default:
                    Debug.Log("fuck");
                    break;
            }
            
            timeToDoAction = false;
        }
    }


    public void dealPhysicalDamage(int unitID, int enemyID) {
        
        //GOPlayerUnits unit = PlayerUnits.find(unitID);
        //GOPlayerUnits enemy = enemyUnits.find(enemyID);

        //enemy.health -= unit.pAttack - enemy.pDefense;
    }

    public void dealMagicDamage(int unitID, int enemyID) {
        //enemyID.health -= unitID.mAttack - enemyID.mDefense;
    }

    public void heal(int unitID, int targetID) {
        //enemyID.health -= unitID.mAttack - enemyID.mDefense;
    }

    public void rally(int unitID, int targetID) {
        //enemyID.health -= unitID.mAttack - enemyID.mDefense;
    }

    public void useItem(int unitID) {
        //enemyID.health -= unitID.mAttack - enemyID.mDefense;
    }

    public void doNothing(int unitID) {
        //enemyID.health -= unitID.mAttack - enemyID.mDefense;
    }

}