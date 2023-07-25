using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MusicManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject stopButton;
    public AudioClip[] audioClips = new AudioClip[6];
    private AudioSource bgm;
    private int musicCount=0;
    public TMP_Text musicName;
    private bool musicStop;
    
    // Start is called before the first frame update
    void Start()
    {
        musicStop = false;
        bgm =GetComponent<AudioSource>();
        playButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (musicStop==true)
        {
           

            stopButton.SetActive(false);
            playButton.SetActive(true);
        }
        else
        {
            

            playButton.SetActive(false);
            stopButton.SetActive(true);

        }
        if (bgm.isPlaying==false&&musicStop==false)
        {
            bgm.clip = audioClips[musicCount];
            bgm.Play();
        }
        musicName.text =string.Format("{0}", audioClips[musicCount].name);
        
    }
    public void PrevMusic()
    {
        if(musicCount>0)
        {
            musicStop = false;
            bgm.Stop();
            musicCount--;
        }
    }
    public void NextMusic()
    {
        if(musicCount<audioClips.Length-1)
        {
            musicStop = false;

            bgm.Stop();
            musicCount++;
        }
    }

    public void StopMusic()
    {
        musicStop = true;
        bgm.Stop();
       
    }
    public void PlayMusic()
    {
        musicStop = false;
        
       
    }


}
