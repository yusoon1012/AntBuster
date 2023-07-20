using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody rigid = default;
    EnemyMove enemyInfo;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;
        enemyInfo = GameObject.FindAnyObjectByType<EnemyMove>();
        Destroy(gameObject, 2.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Debug.Log("콜라이더 : 내 총알이 무언가와 부딪혔다.");
            Destroy(gameObject);
            other.GetComponent<EnemyMove>().Damaged(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       

    }

}
