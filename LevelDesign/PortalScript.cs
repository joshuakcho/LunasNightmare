using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{

    //player gameobject to manipulate the x and y coordinates
    public GameObject Player;

    //portal or object that the player will be teleported towards
    public GameObject SecondPortal;

    //portal entrance animation
    public GameObject PortalSplash;


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            //if the player goes into the ontrigger box collider, starts the coroutine for teleport
            StartCoroutine (Teleport());

            Instantiate(PortalSplash, transform.position, Quaternion.identity);
        }

    }



    IEnumerator Teleport()
    {

        //teleports player after wating a designated amount of seconds
        yield return new WaitForSeconds(1);

        //Player.transform.position = new vector2(SecondPortal.transform.position.x, SecondPortal.transform.position.y);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //loads next scene, scene order found in File -> Build Settings

    }
}
