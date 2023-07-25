using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretButton : MonoBehaviour
{
    public GameObject turretPrefab;

    Ray ray;
    RaycastHit hit;
    Camera cam;
    Button turretButton;
    GameObject spawnObj;
    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        turretButton = GetComponent<Button>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clicked()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (GameManager.currentGold >= GameManager.turretPrice)
        {
            GameManager.currentGold -= GameManager.turretPrice;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 newPosition = hit.point;
                newPosition.y = turretPrefab.transform.position.y;
                spawnObj = Instantiate(turretPrefab, newPosition, turretPrefab.transform.rotation);
            }
            if (GameManager.turretPrice >= 200)
            {
                GameManager.turretPrice += GameManager.turretPrice;
            }
            GameManager.turretPrice += 50;
        }
    }


}
