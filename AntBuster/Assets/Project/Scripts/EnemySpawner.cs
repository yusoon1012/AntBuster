using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRate = 3f;
    private float timeAfterSpawn = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn>=spawnRate)
        {
            timeAfterSpawn = 0;
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}
