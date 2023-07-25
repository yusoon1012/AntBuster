using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartClick()
    {
        SceneManager.LoadScene("PlayScene");

    }
    public void QuitClick()
    {
        Application.Quit();
    }
}
