using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    
    //movement variables
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 20f;

    //animation variable
    public Animator animator;
    public Event onLandEvent;

    //public gameObjects that disappear when the player falls too low and dies
    public GameObject MainUI;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
  
   


    void Start()
    {

        //sets time to normal, for extra security
        Time.timeScale = 1f;

    }



    void Update()
    {

        PlayerMove();
        PlayerFallDeath();
        //PlayerRaycast();   //not used, but have code below for any future reference

    }



    void PlayerMove()
    {

        //controls for jumping and moving sideways
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        //player direction and orientation
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        //animation for running set up here
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        
    }



    void Jump()
    {

        //animator set up for jumping here
        animator.SetBool("IsJumping", true);
        
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;

    }



    void FlipPlayer()
    {

        //flips the player in different direction
        facingRight = !facingRight;
        Vector2 localscale = gameObject.transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;

    }



    //2DCOLLISION TO SEE IF WE WERE GROUNDED
    void OnCollisionEnter2D(Collision2D col)      
    {

        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
            //animator jumping set up here
            animator.SetBool("IsJumping", false);
        }

        if (col.gameObject.tag == "obstacle")
        {
            isGrounded = true;
            //animator jumping set up here
            animator.SetBool("IsJumping", false);
        }
        if (col.gameObject.tag == "enemy")
        {
            isGrounded = true;
            //animator jumping set up here
            animator.SetBool("IsJumping", false);
        }

    }



    public void OnLanding()
    {

        //animation for no longer jumping here
        animator.SetBool("IsJumping", false);

    }



    void PlayerFallDeath()
    {

        //if player falls too low, they die, and gameover screen loads in
        if (gameObject.transform.position.y < -480)   
        {
            MainUI.SetActive(false);
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            Destroy(pauseMenuUI);
        }

    }



    /* void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit != null && hit.collider != null && hit.distance < distanceToBottomOfPlayer && hit.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10000);

            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 7000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 70;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyMove>().enabled = false;

            Instantiate(blood, transform.position, Quaternion.identity);

            isGrounded = false;
        }

    }
    */


    //method that checks whats beneath player, can make player jump when they land on enemy
    /*
    void PlayerRaycast()  //detects what or when we touched the bottom of gameObject, uses raycast from center
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 40f && hit.collider.tag == "enemy")
        {
            
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 60000);     //add force vector upwards to imitate jumping off enemy landing
            isGrounded = false;

            //DESTROYS ENEMY/GAMEOBJECT THAT TOUCHES THE PLAYER WITH THE ENEMY TAG

            Destroy(hit.collider.gameObject);
            
        }

    }
    */



}
