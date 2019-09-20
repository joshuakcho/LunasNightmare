using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{



    //ensures that attacks can only occur every time interval thats set in the editor
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    //sets the attack gizmo from a different gameObject that is a child of the player, edit using the move tool on the child
    public Transform attackPos;

    //Everything in this script only affects gameobject on the layer "enemy"
    public LayerMask whatIsEnemies;

    //attack ranges for x direction, editable in unity editor
    public float attackRangeX;

    //attack ranges for y direction, editable in unity editor
    public float attackRangeY;

    //damage output from the attack, editable in the unity editor
    public int damage;

    //public Animator animator;
    //public Animator camAnim;      //LOOK UP HOW TO ADD CAMERA SHAKE
    public Animator playerAnim;

   
    void Update()
    {
        AttackTime();
    }


    //function that sets the attack time, chamge using the unity editor
    void AttackTime()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                timeBtwAttack = startTimeBtwAttack;
                //camAnim.SetTrigger("shake");
                playerAnim.SetTrigger("attack");

                //the zero represents the angle of the box, can be helpful in future
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                  
                }

            }

            
            //timeBtwAttack = startTimeBtwAttack;
        }




        else
        {
            //animator.SetBool("Attacks", false);
            timeBtwAttack -= Time.deltaTime;
        }

        /*
        if (Input.GetKey(KeyCode.W))
        {
            if (timeBtwAttack <= 0)
            {
                animator.SetBool("Attacks", true);
            }
            else
            {
                animator.SetBool("Attacks", false);
            }
        }
        */
        


    }



    //function that draws the hitbox of attack, change using the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }


}
