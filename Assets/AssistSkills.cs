using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssistSkills : MonoBehaviour
{
    public enum assistType {heal, cure, rally, error}; //there's more assist types, possibly, but I am forgetting them
    public struct AssistSkill{

        public assistType type;
        public int identifier; //identifier is an int that we can use to differentiate the values of say, IED or a simple attack boost
        public int value; //the raw value of the boost

        public AssistSkill(assistType aT, int id, int val)
        {
            this.type = aT;
            this.identifier = id;
            this.value = val;
        }

    }
    public AssistSkill getAssistSkill(string a, int b, int c)
    {
        assistType assist = assistType.error;
        if(String.Equals(a, "heal")) {
            assist = assistType.heal;
        } else if (String.Equals(a, "cure")) {
            assist = assistType.cure;
        } else if (String.Equals(a, "rally")) {
            assist = assistType.rally;
        } else if (String.Equals(a, "error")) {
            assist = assistType.error;
        }

        return new AssistSkill(assist, b, c);
    }
}
