using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private float timeLeft = 120;
    public int player_Score = 0;
    private int player_Key = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject playerScoreDeathUI;
    public GameObject playerKeyUI;

  

    void Update()
    {
        timeLeft -= Time.deltaTime;


        
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + player_Score);

        playerKeyUI.gameObject.GetComponent<Text>().text = ("x  " + player_Key);

        playerScoreDeathUI.gameObject.GetComponent<Text>().text = ("Score: " + player_Score);

        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene ("prototype_1");
        }
    }



    void OnTriggerEnter2D (Collider2D trig)
    {
        if (trig.gameObject.name == "Endlevelmarker")
        {
            CountScore();
        }

        if (trig.gameObject.tag == "coins")
        {
            player_Score += 10;
            player_Key += 1;
            Destroy(trig.gameObject);
        }
    }



  
    void CountScore ()
    {
        player_Score = player_Score + (int)(timeLeft * 10);

        //SceneManager.LoadScene("prototype_1");
        //Debug.Log(player_Score);
    }






}
