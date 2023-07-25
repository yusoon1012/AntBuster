using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyCount = 0;
    public int maxCount;
    public GameObject enemyPrefab;
    private float spawnRate = 3f;
    private float timeAfterSpawn = default;

    // Start is called before the first frame update
    void Start()
    {
        maxCount = 9;
    }

    // Update is called once per frame
    void Update()
    {


        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;
            if (enemyCount < maxCount)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                enemyCount += 1;
            }
        }
    }

    public void DeleteCount(int count_)
    {
        enemyCount -= count_;
    }
}
