using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntLevelManager : MonoBehaviour
{
    public float antExp=0;
    public static int antLevel;
    public void Start()
    {
        antLevel = 1;
    }
    // Start is called before the first frame update
    public void AddExp(float exp_)
    {
        antExp += exp_;
        LevelUp(antExp);
    }
    
    public void LevelUp(float exp_)
    {
        if(exp_%5==0)
        {
            antLevel += 1;
        }
    }
}
