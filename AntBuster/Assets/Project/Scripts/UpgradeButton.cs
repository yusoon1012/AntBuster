using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public GameObject currentPosition;
    public GameObject originTurret;
    public GameObject heavyTurret;
    public GameObject iceTurret;
    private float turretHeight=1.25f;
    Vector3 position;
    Vector3 currentYposition;
    // Start is called before the first frame update
    void Start()
    {
        position = currentPosition.transform.position;
        position.y = heavyTurret.transform.position.y;
        currentYposition = new Vector3(0f, turretHeight, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpgradeHeavy()
    {
        originTurret.SetActive(false);
        GameObject heavy = Instantiate(heavyTurret, currentYposition, heavyTurret.transform.rotation);
        Vector3 newYpos =  currentPosition.transform.position;
        newYpos.y = 1.25f;
        heavy.transform.position = newYpos;
        Destroy(originTurret);
        Destroy(currentPosition);
    }
    public void UpgradeIce()
    {
        originTurret.SetActive(false);
        GameObject ice = Instantiate(iceTurret, currentYposition, iceTurret.transform.rotation);
        Vector3 newYpos = currentPosition.transform.position;
        newYpos.y = 1.25f;
        ice.transform.position = newYpos;
        Destroy(originTurret);
        Destroy(currentPosition);
    }
}
