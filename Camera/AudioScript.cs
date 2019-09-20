using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{



    public AudioClip MusicClip;
    public AudioSource MusicSource;

  


    void Start()
    {
       MusicSource.clip = MusicClip;
    }

    



    public void MainSongOn ()   
    {
        MusicSource.Play();
        DontDestroyOnLoad(transform.gameObject);       //In order to not destroy audio, audio file MUST be in the root of hierarchy
        
    }



    public void MainSongOff()
    {
        MusicSource.Stop();

    }


}
