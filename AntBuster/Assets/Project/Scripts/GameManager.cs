using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static int currentGold;
    public static int turretPrice;
    public static int pizzahp;
    public static int score;
    public static bool isGameOver;
    public GameObject gameOverUi;
    public TMP_Text level;
    public TMP_Text gold;
    public TMP_Text turretGold;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public int icePrice;
    public int heavyPrice;
    public int machineGunPrice;
    private AudioSource mouseSound;

    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        turretPrice = 100;
        currentGold = 100;
        pizzahp = 8;
        isGameOver = false;
        mouseSound = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(mouseSound.isPlaying==true)
            {
                mouseSound.Stop();
                mouseSound.Play();

            }
            else
            {
                mouseSound.Play();

            }
        }
        level.text = string.Format("LV.{0}", AntLevelManager.antLevel);
        gold.text = string.Format("{0}", currentGold);
        scoreText.text = string.Format("SCORE {0}", score);
        turretGold.text = string.Format("{0}", turretPrice);
        float highScore = PlayerPrefs.GetFloat("HighScore");

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        highScoreText.text = "HISCORE :" + highScore;
    }
    public void GameOver()
    {
        gameOverUi.SetActive(true);
        isGameOver = true;
    }
    public void AddGold(int addgold)
    {
        currentGold += addgold;
    }
    public void AddScore(int score_)
    {
        score += score_;
    }

    public void BuyUpgrade(int price_)
    {
        if(price_<=currentGold)
        {
            currentGold -= price_;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
