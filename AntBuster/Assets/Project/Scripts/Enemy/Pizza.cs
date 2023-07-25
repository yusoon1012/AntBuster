using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public GameObject pizza;
    public GameObject[] pizzas;
    public int pizzaHp = 8;
    // Start is called before the first frame update
    void Start()
    {
        pizza = GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pizzaHp == 8)
        {
            pizzas[0].SetActive(true);
            pizzas[1].SetActive(true);
            pizzas[2].SetActive(true);
            pizzas[3].SetActive(true);
            pizzas[4].SetActive(true);
            pizzas[5].SetActive(true);
            pizzas[6].SetActive(true);
            pizzas[7].SetActive(true);
        }
        else if (pizzaHp == 7)
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(true);
            pizzas[2].SetActive(true);
            pizzas[3].SetActive(true);
            pizzas[4].SetActive(true);
            pizzas[5].SetActive(true);
            pizzas[6].SetActive(true);
            pizzas[7].SetActive(true);
        }
        else if (pizzaHp == 6)
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(false);
            pizzas[2].SetActive(true);
            pizzas[3].SetActive(true);
            pizzas[4].SetActive(true);
            pizzas[5].SetActive(true);
            pizzas[6].SetActive(true);
            pizzas[7].SetActive(true);
        }
        else if (pizzaHp == 5)
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(false);
            pizzas[2].SetActive(false);
            pizzas[3].SetActive(true);
            pizzas[4].SetActive(true);
            pizzas[5].SetActive(true);
            pizzas[6].SetActive(true);
            pizzas[7].SetActive(true);
        }
        else if(pizzaHp==4)
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(false);
            pizzas[2].SetActive(false);
            pizzas[3].SetActive(false);
            pizzas[4].SetActive(true);
            pizzas[5].SetActive(true);
            pizzas[6].SetActive(true);
            pizzas[7].SetActive(true);
        }
        else if(pizzaHp==3)
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(false);
            pizzas[2].SetActive(false);
            pizzas[3].SetActive(false);
            pizzas[4].SetActive(false);
            pizzas[5].SetActive(true);
            pizzas[6].SetActive(true);
            pizzas[7].SetActive(true);
        }
        else if(pizzaHp==2)
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(false);
            pizzas[2].SetActive(false);
            pizzas[3].SetActive(false);
            pizzas[4].SetActive(false);
            pizzas[5].SetActive(false);
            pizzas[6].SetActive(true);
            pizzas[7].SetActive(true);
        }
        else if(pizzaHp==1)
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(false);
            pizzas[2].SetActive(false);
            pizzas[3].SetActive(false);
            pizzas[4].SetActive(false);
            pizzas[5].SetActive(false);
            pizzas[6].SetActive(false);
            pizzas[7].SetActive(true);
        }
        else
        {
            pizzas[0].SetActive(false);
            pizzas[1].SetActive(false);
            pizzas[2].SetActive(false);
            pizzas[3].SetActive(false);
            pizzas[4].SetActive(false);
            pizzas[5].SetActive(false);
            pizzas[6].SetActive(false);
            pizzas[7].SetActive(false);
        }
    }

    public void RemovePizza()
    {
        pizzaHp -= 1;
    }
    public void AddPizza()
    {
        pizzaHp += 1;
    }
}
