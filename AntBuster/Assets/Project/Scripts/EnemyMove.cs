using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public int enemyLevel = 1;
    public Slider hpBar;
    public GameObject pickPizza;
    public GameObject pizzaObj;
    public GameObject goalObj;
    private NavMeshAgent agent;
    private Vector3 destination;
    private bool isMove;
    private bool isPizzaPos = false;
    private bool isSlow;
    private float speed;
    
    private float slowTimer=0f;
    private float slowRate = 1.0f;
    EnemySpawner spawner;
    Transform enemyTrans;
    public float enemyHp;
    public float maxHp;
    Pizza pizzaClass;
    Goal goalClass;
    AntLevelManager antLevel;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        isSlow = false;
        pizzaClass = GameObject.FindAnyObjectByType<Pizza>();
        goalClass = GameObject.FindAnyObjectByType<Goal>();
        spawner = GameObject.FindAnyObjectByType<EnemySpawner>();
        antLevel = GameObject.FindAnyObjectByType<AntLevelManager>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        switch(antLevel.antLevel)
        {
            case 1:
                maxHp = 4;
                break;
            case 2:
                maxHp = 5;
                break;
            case 3:
                maxHp = 6;
                break;
            case 4:
                maxHp = 7;
                break;
            case 5:
                maxHp = 8;
                break;
            case 6:
                maxHp = 9;
                break;
            case 7:
                maxHp = 10;
                break;
            case 8:
                maxHp = 11;
                break;
            case 9:
                maxHp = 12;
                break;
            case 10:
                maxHp = 15;
                break;
            default:
                break;
        }
                enemyHp = maxHp;

    }
    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);  //추가
        destination = dest;
        isMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        hpBar.value = enemyHp/maxHp;
        if(isPizzaPos == false)
        {
            SetDestination(pizzaClass.transform.position);

        }
        else
        {
            SetDestination(goalClass.transform.position);
        }
        Vector3 velocity = agent.velocity.normalized;

        // 속도 벡터가 유효한지 검사하고, 유효한 경우 회전을 적용합니다.
        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, agent.angularSpeed * Time.deltaTime);
        }
        if(enemyHp<=0)
        {
            if(isPizzaPos==true)
            {
                pizzaClass.AddPizza();
            }
            if(spawner.enemyCount>0)
            {
                spawner.DeleteCount(1);
                antLevel.AddExp(1);
            }



            Destroy(gameObject);
        }
        if(isSlow==true)
        {
            slowTimer += Time.deltaTime;
            if(slowTimer>=slowRate)
            {
                isSlow = false;
            }
            else
            {
            speed = 3f;
            agent.speed = speed;

            }
        }
        else
        {
            speed = 5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Pizza"))
        {
            isPizzaPos = true;
            pizzaClass.RemovePizza();
            if(pizzaClass.pizzaHp>=0)
            {
                pickPizza.SetActive(true);
            }
            
            Debug.Log("피자");
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
    public void Slow()
    {
        isSlow = true;
    }
}
