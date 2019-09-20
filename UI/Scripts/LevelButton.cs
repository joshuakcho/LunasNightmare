using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour


{


    public void GoBack ()
    {
        SceneManager.LoadScene("MainScreen");
        GameObject.FindGameObjectWithTag("ObjectStop").GetComponent<AudioSource> ().Stop();     //stops audio playing if it has ObjectStop tag placed on its audio
    }




}
