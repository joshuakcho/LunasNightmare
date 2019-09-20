using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour


{

   

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);   //loads next scene, scene order found in File -> Build Settings
    }




    public void QuitGame ()
    {
        Debug.Log("Game's Quit");
        Application.Quit();
    }




}
