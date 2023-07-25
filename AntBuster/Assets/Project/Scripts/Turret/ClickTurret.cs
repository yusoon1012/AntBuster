using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTurret : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public BulletSpawner spawner;
    private bool isClick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                    if (isClick == false)
                    {

                        isClick = true;
                        

                    }
                    else
                    {
                        isClick = false;
                    }
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                if (this.transform == hit.transform)
                {
                    spawner.IsClicked(isClick);
                }




            }


        }


    }
}
