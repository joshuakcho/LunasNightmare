using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //the health/amount of hearts a player has currently
    public int health;

    //full amount of health possible
    public int numOfHearts;

    //heart sprite array
    public Image[] hearts;

    //sprites of both a full and empty heart
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //blood effect
    public GameObject blood;

    //gameobject for the gameOver screen that pops up when the enemy touches the player/kills them
    public GameObject gameOverUI;
    public GameObject MainUI;
    public GameObject pauseMenuUI;


    //public Animator heartAnim;



    // Update is called once per frame
    void Update()
    {
        PlayerHearts();
    }



    //function that sets the hearts up for player UI
    void PlayerHearts()
    {

        //statement that ensures if amount of health is greater than number of hearts, it limits it
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        
        for (int i = 0; i < hearts.Length; i++)
        {

            //for loop that set the amount of full hearts using the health variable
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //statment that only shows heart sprites based on the number of hearts variable thats set in the editor
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
        

    }



    //2d collision detector that kills the player when they touch enemy, and reduces the hearts
    void OnCollisionEnter2D(Collision2D col)
    {

        //statment that reduces player hearts if the enemy touches player
        if (col.gameObject.tag == "enemy")
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            health -= 1;
        }

        if (health <= 0)
        {
            PlayerKill();
        }

    }



    //function that kills player by loading game over screen
    void PlayerKill()
    {
        gameOverUI.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0f;
        Destroy(pauseMenuUI);
    }




}
