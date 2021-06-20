using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGoblinMovement : MonoBehaviour
{
    float scaleX, scaleY;//default scale Values;
    GameObject Player;
    Animator anm;
    int lives;
    public bool DontMove, Died;
    float lastY;
    // Start is called before the first frame update
    void Start()
        {
        Died = false;
        lives = 3;
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
        if (lives == 0 && !Died)
            {
            Die();
            }

        if (!DontMove)
            {
            if (Player.transform.position.x > transform.position.x && !anm.GetBool("IsAttacking"))//changing the Goblin position based on its direction from the player
                {
                transform.localScale = new Vector3(scaleX, scaleY, 0);
                transform.Translate(5 * Time.deltaTime, 0, 0);
                }
            else if (Player.transform.position.x < transform.position.x && !anm.GetBool("IsAttacking"))//changing the Goblin position based on its direction from the player
                {
                transform.localScale = new Vector3(-scaleX, scaleY, 0);
                transform.Translate(-5 * Time.deltaTime, 0, 0);
                }
            if (Mathf.Abs(transform.position.x - Player.transform.position.x) <= 4.5)
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
        GameObject.Find("TutorialManager").GetComponent<TutorialManagerScript>().GoblinDied();
        }
    }

