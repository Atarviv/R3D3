using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerMovementWithBattery : MonoBehaviour
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
            GetComponent<TutorialBatteryScript>().ChangeBattery(-0.01f);
            }
        else if (Input.GetKey(KeyCode.LeftArrow))
            {
            transform.localScale = new Vector2(-1, 1);
            transform.Translate(-10 * Time.deltaTime, 0, 0);
            ame.SetBool("isRunning", true);
            GetComponent<TutorialBatteryScript>().ChangeBattery(-0.01f);
            }
        else
            {
            ame.SetBool("isRunning", false);
            }
        }
    private void OnTriggerEnter2D(Collider2D collision)
        {
        if(collision.gameObject.tag == "Battery")
            {
            GetComponent<TutorialBatteryScript>().ChangeBattery(10);
            Destroy(collision.gameObject);
            }
        }
    }
