using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerJump : MonoBehaviour
{
    Animator ame;
    bool onTheGround;
    // Start is called before the first frame update
    void Start()
    {
        ame = GetComponent<Animator>();

        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && onTheGround && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < 2)
            {
            onTheGround = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            ame.SetBool("isJumping", false);
            ame.SetBool("isJumping", true);
            }
        }
    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "Ground")
            {
            onTheGround = true;
            ame.SetBool("isJumping", false);
            ame.SetBool("isRunning", false);
            }
        }
    }
