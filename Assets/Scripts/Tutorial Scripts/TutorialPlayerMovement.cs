using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerMovement : MonoBehaviour
{
    Animator ame;
    // Start is called before the first frame update
    void Start()
    {
        ame = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            {
            transform.localScale = new Vector2(1, 1);
            transform.Translate(10 * Time.deltaTime, 0, 0);
            ame.SetBool("isRunning", true);
            }
        else if (Input.GetKey(KeyCode.LeftArrow))
            {
            transform.localScale = new Vector2(-1, 1);
            transform.Translate(-10 * Time.deltaTime, 0, 0);
            ame.SetBool("isRunning", true);
            }
        else
            {
            ame.SetBool("isRunning", false);
            }

        }
    }
