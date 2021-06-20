using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    float scaleX, scaleY;//default scale Values;
    GameObject Player;
    public int GoblinLevel;
    Animator anm;
    int lives;
    public bool DontMove,Died;
    float lastY;
    // Start is called before the first frame update
    void Start()
    {
        Died = false;
        lives = GoblinLevel;
        DontMove = false;
        Player = GameObject.Find("Robot");
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        anm = GetComponent<Animator>();
        lastY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0&&!Died)
            {
            Die();
            }

        if (Mathf.Abs(Player.transform.position.y - transform.position.y) < 0.5  && Mathf.Abs(Player.transform.position.x - transform.position.x) < 50&&!DontMove)
            {
            if (Player.transform.position.x > transform.position.x && !anm.GetBool("IsAttacking"))//changing the Goblin position based on its direction from the player
                {
                transform.localScale = new Vector3(scaleX, scaleY, 0);
                transform.Translate(3 * GoblinLevel * Time.deltaTime, 0, 0);
                }
            else if (Player.transform.position.x < transform.position.x&&!anm.GetBool("IsAttacking"))//changing the Goblin position based on its direction from the player
                {
                transform.localScale = new Vector3(-scaleX, scaleY, 0);
                transform.Translate(-3 * GoblinLevel * Time.deltaTime, 0, 0);
                }
            if (Mathf.Abs(transform.position.x - Player.transform.position.x) <= 4)
                {
                anm.SetBool("IsAttacking", true);
                }
            else
                {
                anm.SetBool("IsAttacking", false);
                anm.SetBool("IsWalking", true);
                }
            }
        else
            {
            anm.SetBool("IsAttacking", false);
            anm.SetBool("IsWalking", false);
            }
        }

        
    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "Goblin")
            {
            if((transform.localScale.x>0&&collision.transform.position.x>transform.position.x)|| (transform.localScale.x < 0 && collision.transform.position.x < transform.position.x))
            DontMove = true;
            }

        }
    private void OnCollisionExit2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "Goblin") DontMove = false;

        }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Laser")
            {
            lives--;
            }
        }
    public void Die()
        {
        DontMove = true;
        Died = true;
        anm.SetTrigger("Die");
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
