using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretPosition : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    GameObject turret;
    private bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0))
        {
            if (isClicked == false)
            {
                isClicked = true;
            }
            else
            {
                isClicked = false;
            }
           
        }
        if(isClicked==true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Turret1_Move")
                {

                    Vector3 newPosition = hit.point;
                    newPosition.y = hit.transform.position.y;
                    hit.transform.position = newPosition;
                    Debug.Log(hit.transform.name);
                }
                // do something
            }
        }
    }
    
}
