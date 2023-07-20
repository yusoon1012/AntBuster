using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class EnemyMove : MonoBehaviour
{
    public int enemyLevel = 1;
    public GameObject pizzaObj;
    public GameObject goalObj;
    private NavMeshAgent agent;
    private Vector3 destination;
    private bool isMove;
    private bool isPizzaPos = false;
    Transform enemyTrans;
    private float enemyHp;
    Pizza pizzaClass;
    Goal goalClass;
    

    // Start is called before the first frame update
    void Start()
    {
        pizzaClass = GameObject.FindAnyObjectByType<Pizza>();
        goalClass = GameObject.FindAnyObjectByType<Goal>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        enemyHp = 4;
    }
    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);  //�߰�
        destination = dest;
        isMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(isPizzaPos == false)
        {
            SetDestination(pizzaClass.transform.position);

        }
        else
        {
            SetDestination(goalClass.transform.position);
        }
        Vector3 velocity = agent.velocity.normalized;

        // �ӵ� ���Ͱ� ��ȿ���� �˻��ϰ�, ��ȿ�� ��� ȸ���� �����մϴ�.
        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, agent.angularSpeed * Time.deltaTime);
        }
        if(enemyHp<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Pizza"))
        {
            isPizzaPos = true;
            Debug.Log("����");
        }
        if(isPizzaPos==true&&other.tag.Equals("Goal"))
        {
            Destroy(gameObject);
        }
    }

    public void Damaged(float damage)
    {
        enemyHp -= damage;
    }

}
