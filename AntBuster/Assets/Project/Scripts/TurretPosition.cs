using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretPosition : MonoBehaviour,IPointerClickHandler,IDragHandler
{
   
    BulletSpawner spawner;
    Ray ray;
    RaycastHit hit;
    GameObject objectHitPosition;
    RaycastHit hitLayerMask;
    Vector3 distance;
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
                objectHitPosition = new GameObject("HitPosition");
                objectHitPosition.transform.position = hit.point;
                this.transform.SetParent(objectHitPosition.transform);
                isClicked = true;
            }
            else
            {
                isClicked = false;
                
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
        
        if (isClicked == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                

                if (hit.transform.name == "Turret1_Move"|| hit.transform.name == "Turret1_Move(Clone)")
                {
                    
                    //spawner.IsClicked(isClicked);

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
                    Debug.Log(hit.transform.name);
                }
                // do something
                
            }
        }
        else
        {
            distance = Vector3.zero;
            this.transform.parent = null;
            Destroy(objectHitPosition);
           
            
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
