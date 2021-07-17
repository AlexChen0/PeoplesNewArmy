using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    //we need to differentiate between our turn and enemy turn, this can be decided 
    //by whenever we are forced to end turn or voluntarily do so, and similarly when 
    //enemy AI makes those decisions.
    //'off' refers to when we are in cutscenes, battle prep, etc.  
    public enum turn {Player, Enemy, Off, Error};
    public turn currentTurn;
    // Start is called before the first frame update
    void Start()
    {
        turn currentTurn;

        currentTurn = turn.Player;
    }

    // Update is called once per frame
    void endTurn()
    {
        switch(currentTurn)
        {
            case turn.Player:
                currentTurn = turn.Enemy;
                break;
            case turn.Enemy:
                currentTurn = turn.Player;
                break;
        }
    }

    void endMap()
    {
        currentTurn = turn.Off;
    }

    void startMap()
    {
        currentTurn = turn.Player;
    }
}
