using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager : MonoBehaviour
{
    public List<GameObject> PlayerUnits = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.GameObject[] GOPlayerUnits;
        GOPlayerUnits = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject i in GOPlayerUnits)
        {
            PlayerUnits.Add(i);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
