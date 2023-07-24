using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BulletSpawner : MonoBehaviour
{
    public enum TurretState
    {
        Installation,
        Upgrade,
    }

    public GameObject shootingRange;
    public GameObject muzzleFire = default;
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    public Animator turretAni;
    public bool isFirstSet;
    public int type;

    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;
    private float rotationSpeed = 250f;
    private bool isPlayerIn = default;
    NavMeshObstacle obstacle;
    private bool isShooting = default;
    public float bulletHeight;

    private bool targetOn = false;
    private Transform targetTrans;
    private bool targetInRange = false;
    private Vector3 targetPosition;
    private bool isClick = false;


    public TurretState turretState;

    private AudioSource shootSound;
    // Start is called before the first frame update
    void Start()
    {
        isFirstSet = true;
        shootSound = GetComponent<AudioSource>();
        obstacle = GetComponent<NavMeshObstacle>();
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //target = FindObjectOfType<EnemyMove>().transform;
        obstacle.carving = true;
        //originalYRotation = transform.eulerAngles.y;
        turretState = TurretState.Installation;

    }

    private void OnTriggerStay(Collider other)
    {
        //    //PlayerController playerControler = other.GetComponent<PlayerController>();
        //    EnemyMove eneycontrol = other.GetComponent<EnemyMove>();
        if (other.tag.Equals("Enemy"))
        {
            targetInRange = true;
            if (targetTrans == null)
            {
                targetTrans = other.transform;
                targetOn = true;
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && targetOn == false)
        {
            targetOn = true;
            targetTrans = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target)
        {
            targetOn = false;
            targetTrans = null;
        }
        if (other.tag.Equals("Enemy"))
        {
            targetInRange = false;
            targetOn = false;
            targetTrans = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick == false)
        {
            shootingRange.SetActive(false);
        }
        else
        {
            shootingRange.SetActive(true);
        }
        isShooting = false;

        turretAni.SetBool("Shoot", isShooting);

        if (targetOn == true && targetTrans != null)
        {
            if (IsTargetAlive(targetTrans) && IsTargetInRange(targetTrans))
            {

                targetPosition = new Vector3(targetTrans.transform.position.x, transform.position.y, targetTrans.transform.position.z);
                transform.LookAt(targetPosition);
                timeAfterSpawn += Time.deltaTime;
                if (timeAfterSpawn >= spawnRate)
                {
                    Vector3 bulletSpawnPosition = transform.position + transform.forward * bulletHeight;


                    timeAfterSpawn = 0;
                    Vector3 muzzleRotation = new Vector3(0f, 90f, 0f);
                    Quaternion mzlRotation = Quaternion.Euler(muzzleRotation);
                    GameObject muzzle = Instantiate(muzzleFire, bulletSpawnPosition, transform.rotation);
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, transform.rotation);
                    bullet.transform.LookAt(targetPosition);
                    isShooting = true;
                    spawnRate = spawnRateMin;
                    shootSound.Play();
                    Destroy(muzzle, 0.5f);

                }

            }
            else
            {
                targetOn = false;
                targetTrans = null;
            }
            //if(isPlayerIn==false)
            //   {
            //       transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);

            //   }


        }

    }

    public bool IsClicked(bool click)
    {
        isClick = click;
        return isClick;
    }
    private bool IsTargetAlive(Transform target_)
    {
        if (target_.GetComponent<EnemyMove>().enemyHp == 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    private bool IsTargetInRange(Transform target_)
    {
        if (targetInRange == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

