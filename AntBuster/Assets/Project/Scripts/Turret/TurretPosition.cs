using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretPosition : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public enum turretState
    {
        installation, upgrade,
    }
    public GameObject upgradeUi;
    public BulletSpawner spawner;
    Ray ray;
    RaycastHit hit;
    GameObject objectHitPosition;
    RaycastHit hitLayerMask;
    Vector3 distance;
    private bool isClicked = false;
    private bool firstSet;
    turretState state;



    // Start is called before the first frame update
    void Start()
    {

        state = turretState.installation;
        firstSet = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isClicked == false && state == turretState.installation)
        {
            objectHitPosition = new GameObject("HitPosition");
            objectHitPosition.transform.position = hit.point;
            this.transform.SetParent(objectHitPosition.transform);
            isClicked = true;
            
        }

        if (Input.GetMouseButtonDown(0) && state == turretState.installation)
        {
            if (isClicked == false)
            {
                isClicked = true;
            }
            if (isClicked == true && firstSet == true)
            {
                isClicked = false;
                firstSet = false;
                distance = Vector3.zero;
                this.transform.parent = null;
                Destroy(objectHitPosition);
                state = turretState.upgrade;

            }
            if (isClicked == true)
            {
                isClicked = false;
                distance = Vector3.zero;
                this.transform.parent = null;
                Destroy(objectHitPosition);

            }

        }
        if (state == turretState.installation)
        {
            upgradeUi.SetActive(false);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (isClicked == true)
                {
                    if (hit.transform == this.transform)
                    {

                    //if (hit.transform.name == "Turret1_Move" || hit.transform.name == "Turret1_Move(Clone)")
                    //{

                        spawner.IsClicked(true);

                        float H = Camera.main.transform.position.y;
                        float h = objectHitPosition.transform.position.y;

                        Vector3 newPos
                            = (hitLayerMask.point * (H - h) + Camera.main.transform.position * h) / H;
                        objectHitPosition.transform.position = newPos;
                        //if (distance == Vector3.zero)
                        //{
                        //    distance = this.transform.position - hit.point;
                        //}
                        Vector3 newPosition = hit.point;
                        newPosition.y = hit.transform.position.y;
                        hit.transform.position = newPosition;
                    }
                    else if (hit.transform.tag != "Turret")
                    {
                        spawner.IsClicked(false);
                        
                    }

                    //}

                }


            }

        }
        //Debug.LogFormat("state : {0}", state);
        if (state == turretState.upgrade)
        {
            spawner.ChangeState();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                //Debug.Log(hit.transform.name);
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform == this.transform)
                    {

                        //if (hit.transform.tag == "Turret")
                        //{
                        if (isClicked == false)
                        {
                            isClicked = true;
                        }
                        else
                        {
                            isClicked = false;
                        }


                        // }
                        spawner.IsClicked(isClicked);
                        upgradeUi.SetActive(isClicked);


                    }
                    
                }
            }
        }
        //if (isClicked == true)
        //{
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.name == "Turret1_Move")
        //        {

        //            float H = Camera.main.transform.position.y;
        //            float h = objectHitPosition.transform.position.y;

        //            Vector3 newPos
        //                = (hitLayerMask.point * (H - h) + Camera.main.transform.position * h) / H;
        //            objectHitPosition.transform.position = newPos;
        //            //if (distance == Vector3.zero)
        //            //{
        //            //    distance = this.transform.position - hit.point;
        //            //}
        //            Vector3 newPosition = hit.point;
        //            newPosition.y = hit.transform.position.y;
        //            hit.transform.position = newPosition;
        //            Debug.Log(hit.transform.name);
        //        }
        //        // do something
        //    }
        //}
        //else
        //{
        //    distance = Vector3.zero;
        //    this.transform.parent = null;
        //    Destroy(objectHitPosition);
        //}
    }//update()

    void FixedUpdate()
    {




    }
    public void OnDrag(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
