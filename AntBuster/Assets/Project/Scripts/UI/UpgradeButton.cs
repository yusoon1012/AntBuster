using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public GameObject currentPosition;
    public GameObject originTurret;
    public GameObject heavyTurret;
    public GameObject iceTurret;
    public GameObject machineGunTurret;
   
    public int icePrice = 300;
    public int heavyPrice = 500;
    public int machineGunPrice = 800;
    private float turretHeight=1.25f;
    Vector3 position;
    Vector3 currentYposition;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        position = currentPosition.transform.position;
        position.y = heavyTurret.transform.position.y;
        currentYposition = new Vector3(0f, turretHeight, 0f);
        manager = GameObject.FindAnyObjectByType<GameManager>();
       
    }

    // Update is called once per frame
    
    public void UpgradeHeavy()
    {
        if(heavyPrice<=GameManager.currentGold)
        {
            GameManager.currentGold -= heavyPrice;
        originTurret.SetActive(false);
        GameObject heavy = Instantiate(heavyTurret, currentYposition, heavyTurret.transform.rotation);
        Vector3 newYpos =  currentPosition.transform.position;
        newYpos.y = 1.25f;
        heavy.transform.position = newYpos;
        Destroy(originTurret);
        Destroy(currentPosition);
        }
        
    }
    public void UpgradeIce()
    {
        if(icePrice<=GameManager.currentGold)
        {
            GameManager.currentGold -= icePrice;
        originTurret.SetActive(false);
        GameObject ice = Instantiate(iceTurret, currentYposition, iceTurret.transform.rotation);
        Vector3 newYpos = currentPosition.transform.position;
        newYpos.y = 1.25f;
        ice.transform.position = newYpos;
        Destroy(originTurret);
        Destroy(currentPosition);
        }
      
    }
    public void UpgradeMachineGun()
    {
        if(machineGunPrice<=GameManager.currentGold)
        {
            GameManager.currentGold -= machineGunPrice;
        originTurret.SetActive(false);
        GameObject machine = Instantiate(machineGunTurret, currentYposition, machineGunTurret.transform.rotation);
        Vector3 newYpos = currentPosition.transform.position;
        newYpos.y = 1.25f;
        machine.transform.position = newYpos;
        Destroy(originTurret);
        Destroy(currentPosition);
        }
        
    }
}
