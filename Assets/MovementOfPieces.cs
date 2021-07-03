using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfPieces : MonoBehaviour
{
    private bool isClicking; // remove true when generalized control is done
    private GameObject selection;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
