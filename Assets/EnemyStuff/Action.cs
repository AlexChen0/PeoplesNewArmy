using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Will handle actions similar to the action handler of the player action handler stuff
*/

public class Action : MonoBehaviour
{

    public Action createPrimitiveAttack(CombatUnit unit, Direction dir) {
        //will instruct which unit to attack which
        return null;
    }

    public Action createPrimitiveMove(CombatUnit attacking, CombatUnit recieving) {
        //will instruct which unit to move
        return null;
    }
}
