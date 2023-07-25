//using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public int enemyLevel = 1;
    public Slider hpBar;
    public GameObject pickPizza;
    private GameObject pizzaObj;
    private GameObject goalObj;
   
    private NavMeshAgent agent;
    private Vector3 destination;
   
    private bool isPizzaPos = false;
    private bool isSlow;
    private bool isRightTop = false;
    private bool isLeftBottom = false;
    private float speed;
    private int randomDest;
    private float slowTimer=0f;
    private float slowRate = 3.0f;
    private bool isPizzaOn = false;
    EnemySpawner spawner;
    Transform enemyTrans;
    public float enemyHp;
    public float maxHp;
    Pizza pizzaClass;
    Goal goalClass;
    RightTop rightTop;
    LeftBottom leftBottom;
    AntLevelManager antLevel;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        isSlow = false;
        pizzaClass = GameObject.FindAnyObjectByType<Pizza>();
        goalClass = GameObject.FindAnyObjectByType<Goal>();
        spawner = GameObject.FindAnyObjectByType<EnemySpawner>();
        antLevel = GameObject.FindAnyObjectByType<AntLevelManager>();
        rightTop = GameObject.FindAnyObjectByType<RightTop>();
        leftBottom = GameObject.FindAnyObjectByType<LeftBottom>();
        manager = GameObject.FindAnyObjectByType<GameManager>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;


        randomDest = Random.Range(0, 3);

            maxHp += 4+(AntLevelManager.antLevel/3);
        
                enemyHp = maxHp;

    }
    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);  //추가
        destination = dest;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.isGameOver==true)
        {
            return;
            
        }
        hpBar.value = enemyHp/maxHp;
        if (isPizzaPos == false && randomDest == 1&&isRightTop==false)
        {
            SetDestination(rightTop.transform.position);
        }
        else if(isPizzaPos==false&&randomDest==2&&isLeftBottom==false)
        {
            SetDestination(leftBottom.transform.position);
        }
        else
        {
            SetDestination(pizzaClass.transform.position);

        }
        //if (isPizzaPos==false&&transform.position==rightTop.transform.position)
        //{

        //    SetDestination(pizzaClass.transform.position);
        //}
        if(isPizzaPos==true&&randomDest==1&&isRightTop==false)
        {
            SetDestination(rightTop.transform.position);
        }
        else if (isPizzaPos == true && randomDest == 2 && isLeftBottom == false)
        {
            SetDestination(leftBottom.transform.position);

        }
        else if (isPizzaPos==true)
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
            if(isPizzaOn == true)
            {
                pizzaClass.AddPizza();
            }
            if(spawner.enemyCount>0)
            {
                spawner.DeleteCount(1);
                antLevel.AddExp(1);
            }
            manager.AddScore(50);
            manager.AddGold(20);

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
            speed = 2f;
            agent.speed = speed;

            }
        }
        else
        {
            speed = 5f;
            agent.speed = speed;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Pizza"))
        {
            isPizzaPos = true;
            if(pizzaClass.pizzaHp>0)
            {
                isPizzaOn = true;
                pickPizza.SetActive(true);
                pizzaClass.RemovePizza();
            }
            isLeftBottom = false;
            isRightTop = false;
            //Debug.Log("피자");
        }
        if(isPizzaOn == true&&other.tag.Equals("Goal"))
        {
            spawner.DeleteCount(1);
            GameManager.pizzahp -= 1;
            Destroy(gameObject);
            if(GameManager.pizzahp==0)
            {
                manager.GameOver();
            }


        }
        if(other.tag.Equals("RightTop"))
        {
            isRightTop = true;
        }
        if (other.tag.Equals("LeftBottom"))
        {
            isLeftBottom = true;
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
