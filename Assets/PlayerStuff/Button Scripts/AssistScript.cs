using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AssistScript : MonoBehaviour
{
    //this script is a close mirror to attackHandler, but the difference is that you are selecting allies instead of enemies to assist. 
    public GameObject Selectionbox;
    public PlayerUnitManager PUM; 
    public characteristics chara;
    public Vector2 coords = new Vector2(0,0);
    public int SI = 0;

    public PlayerUnit assistingUnit;
    public List<PlayerUnit> targetableAllies = new List<PlayerUnit>();

    public GameObject popUpBox;

    public int targetSelection;

    //Start is called before the first frame update
    public void ButtonClicked()
    {
        Debug.Log("AssistScript was called!");
        Selectionbox = GameObject.Find("Controller");
        PUM = Selectionbox.GetComponent<PlayerUnitManager>();
        chara = Selectionbox.GetComponent<characteristics>();

        for(int i = 0; i < PUM.PlayerUnits.Count; i++)
        {
            if(Selectionbox.transform.position.x == PUM.PlayerUnits[i].transform.position.x 
            && Selectionbox.transform.position.y == PUM.PlayerUnits[i].transform.position.y)
            {
                SI = i;
                break;
            }
        }
        //now this can be used alongside characteristics

        assistingUnit = chara.getUnit(SI);

        //absolutely cursed programming LMAO 
        for(int i = 0; i < PUM.PlayerUnits.Count; i++)
        {
            if(Mathf.Abs((PUM.PlayerUnits[i].transform.position.x - PUM.PlayerUnits[SI].transform.position.x) 
                            + (PUM.PlayerUnits[i].transform.position.y - PUM.PlayerUnits[SI].transform.position.y)) < assistingUnit.equipmentPointer && i != SI)
            {
                //the equipmentpointer thing serves as a workaround tentatively while we dont need to access range directly yet. don't forget to change this.
                targetableAllies.Add(chara.getUnit(i));
            }
        }

        //allies now targetable, make this a different popupbox from attackhandler
        popUpBox.SetActive(true);
    }

}
