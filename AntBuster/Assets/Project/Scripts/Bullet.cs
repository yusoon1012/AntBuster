using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int bulletType;
    public float speed = default;
    private Rigidbody rigid = default;
    EnemyMove enemyInfo;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;
        enemyInfo = GameObject.FindAnyObjectByType<EnemyMove>();
        Destroy(gameObject, 1.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if(bulletType==1)
            {
                other.GetComponent<EnemyMove>().Slow();
            }
            Destroy(gameObject);
            other.GetComponent<EnemyMove>().Damaged(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       

    }

}
