using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject MainUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }

        }

    }



    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        MainUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }



    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        MainUI.SetActive(false);
       
    }


    public void LoadMenu()
    {

        
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScreen");
        //GameObject.FindGameObjectWithTag("ObjectStop").GetComponent<AudioSource>().Stop();     //stops audio playing if it has ObjectStop tag placed on its audio

    }


    public void Restart()
    {


        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //loads next scene, scene order found in File -> Build Settings

        //SceneManager.LoadScene("prototype_1");
        //GameObject.FindGameObjectWithTag("ObjectStop").GetComponent<AudioSource>().Stop();     //stops audio playing if it has ObjectStop tag placed on its audio

    }


    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }


}
