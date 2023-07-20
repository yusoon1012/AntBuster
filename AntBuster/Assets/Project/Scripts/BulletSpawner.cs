using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    public Animator turretAni;
    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;
    private float rotationSpeed = 250f;
    private bool isPlayerIn = default;
    NavMeshObstacle obstacle;
    private bool isShooting = default;
    private float bulletHeight = 1.0f;
   
    private Vector3 targetPosition;


    private AudioSource shootSound;
    // Start is called before the first frame update
    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        obstacle = GetComponent<NavMeshObstacle>();
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //target = FindObjectOfType<EnemyMove>().transform;
        obstacle.carving = true;
        //originalYRotation = transform.eulerAngles.y;
    }

    private void OnTriggerStay(Collider other)
    {
        //PlayerController playerControler = other.GetComponent<PlayerController>();
        EnemyMove eneycontrol = other.GetComponent<EnemyMove>();
        if (eneycontrol != null)
        {
            targetPosition = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            transform.LookAt(targetPosition);
            timeAfterSpawn += Time.deltaTime;
            if (timeAfterSpawn >= spawnRate)
            {
                Vector3 bulletSpawnPosition = transform.position + transform.forward * bulletHeight;
                timeAfterSpawn = 0;
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, transform.rotation);
                bullet.transform.LookAt(targetPosition);
                isShooting = true;
                spawnRate = spawnRateMin;
                shootSound.Play();

            }
           
            

            isPlayerIn = true;
        }
        else
        {
            isPlayerIn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        isShooting = false;

        turretAni.SetBool("Shoot", isShooting);

   
        //if(isPlayerIn==false)
        //   {
        //       transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);

        //   }


    }
   
}
