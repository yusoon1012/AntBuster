using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int pizzahp;
    public GameObject gameOverUi;
    public TMP_Text level;
    // Start is called before the first frame update
    void Start()
    {
        pizzahp = 8;
    }

    // Update is called once per frame
    void Update()
    {
        level.text = string.Format("LV.{0}", AntLevelManager.antLevel);
    }
    public void GameOver()
    {
        gameOverUi.SetActive(true);
    }
}
