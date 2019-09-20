using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    //variable raycast distance
    private float EnemyRayDistance;

    //enemy speed movement ALSO CHANGE THE DAZED TIME FUNCTION BELOW TO SYNC SPEEDS UP
    public float speed;

    //checks to see if enemy is moving right
    private bool movingRight = true;

    //gameobject ground/lower detection using a gizmo from empty gameobject
    public Transform groundDetection;

    //gameobject to hold blood particle system
    public GameObject BloodSplash;

    //gives the enemy health, give value in the editor
    public int health;

    //EnemyDazed values, time before enemy starts moving again
    private float dazedTime;
    public float startDazedTime;



    void Update()
    {
        EnemyDetectDown();
        //2D collision function is below, checks if target collides
        Health();
        DazedTime();
        EnemyMove();
    }


    void EnemyMove()
    {

        //sets speed of enemy by multiplying a factor and delta time to keep it independent of framerate
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }



    void EnemyDetectDown()
    {
        //raycast that takes info from the gizmo of GameObject "ground detection" (A child of the enemy gameobject) and points straight down to detect ground
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down);


        //statement that checks to see if theres any ground blocks/detection
        if (groundInfo.collider == false)
        {

            //flips enemy by 180 degrees if theres no ground blocks/detection from the RayCast
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }



    //2D COLLISION DETECTOR THAT FLIPS ENEMY AROUND IF THEY HIT ANY GAMEOBJECT WITH TAG "OBSTACLE"
    void OnCollisionEnter2D(Collision2D col)
    {
        //statment that makes enemy flip direction if collided with block on side, uses the box collider
        if (col.gameObject.tag == "obstacle" || col.gameObject.tag == "enemy" || col.gameObject.tag == "Player")
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }



    //taking damage function. increments hit points onto an enemies overall health
    public void TakeDamage(int damage)
    {
        
        dazedTime = startDazedTime;

        //summons blood when enemy get hit/takes damage
        Instantiate(BloodSplash, transform.position, Quaternion.identity);

        health -= damage;
        //Debug.Log("damage TAKEN !");
        



    }



    //health function
    void Health()
    {
        if (health <= 0)
        {
            //kills enemy when health reaches 0
            Destroy(gameObject);
        }
    }



    //makes enemy pause after getting hit, imitating a dazed effect
    void DazedTime()
    {
        if (dazedTime <= 0)
        {
            speed = speed;
        }
        else
        {
            speed = 0f;
            dazedTime -= Time.deltaTime;
        }
    }

}
