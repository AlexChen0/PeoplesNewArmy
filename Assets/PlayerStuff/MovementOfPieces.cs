using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementOfPieces : MonoBehaviour
{
    private bool isClicking; // remove true when generalized control is done
    private GameObject selection;
    private int selectionindex = -1;
    private PlayerUnitManager PUM; 
    private PlayerStats playerstats;
    public PlayerUnit testing;
    public EnemyUnit enemytesting;
    // Start is called before the first frame update
    public GameObject actionSelector;
    public GameObject theController;

    public bool canMove = true;

    void Start()
    {
        PUM = GetComponent<PlayerUnitManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            transform.position = transform.position + new Vector3(0, 1, 0);
        }
        if(canMove && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            transform.position = transform.position + new Vector3(0, -1, 0);
        }
        if(canMove && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.position = transform.position + new Vector3(-1, 0, 0);
        }
        if(canMove && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.position = transform.position + new Vector3(1, 0, 0);
        }
        if(canMove && Input.GetKeyDown(KeyCode.Escape))
        {
            selectionindex = -1;
        }
        if(canMove && Input.GetKeyDown(KeyCode.Space))
        {
            //assign variables that associate with the selector's x and y coordinates
            if(selectionindex == -1)
            {
                for(int i = 0; i < PUM.PlayerUnits.Count; i++)
                {
                    if(transform.position.x == PUM.PlayerUnits[i].transform.position.x 
                    && transform.position.y == PUM.PlayerUnits[i].transform.position.y)
                    {
                        selectionindex = i;
                        //we need to find the movement distance that is covered by this particular player. How do we do this?
                        playerstats = PUM.PlayerUnits[i].GetComponent<PlayerStats>();
                        break;
                    }
                }
   
            }
            else
            {
                if(Mathf.Abs((transform.position.x - PUM.PlayerUnits[selectionindex].transform.position.x) 
                            + transform.position.y - PUM.PlayerUnits[selectionindex].transform.position.y) < playerstats.move) // in movement range
                {

                    PUM.PlayerUnits[selectionindex].transform.position = transform.position;
                    selectionindex = -1;

                    actionSelector.SetActive(true);
                    canMove = false;
                    //will need to think of alternative workaround
                    //theController.SetActive(false);
                    //wake up the UI that selects for attacking
                        //see script that handles attacking, attached to attack button
                }
                else
                {
                    Debug.Log("unit cannot move there!");
                }
            }

        }

        /*
        if(Input.GetKeyDown(KeyCode.F))
        {
            //https://www.youtube.com/watch?v=VaDhk2eOQXM
            make a popup menu for attack options
        }
        */
        /*
        if(Input.GetMouseButtonUp(0) && !isClicking)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenPos = cam.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(screenPos,Vector2.zero);
            if(hit)
            {
                isClicking = true;
                selection = GameObject.Find(hit.collider.gameObject.name);
            }
        }

        if(Input.GetMouseButtonDown(0) && isClicking)
        {
            Debug.Log(selection.name);
            isClicking = false;
            Vector3 mousePos1 = Input.mousePosition;
            Vector3 screenPos1 = cam.ScreenToWorldPoint(mousePos1);
            float xx = screenPos1.x - .5f;
            float yy = screenPos1.y + .5f;
            int dx = (int) xx;
            int dy = (int) yy;
            selection.transform.position = new Vector2(dx, dy);  
            selection = null;
        }
        */
    }
}
