using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerSlide : MonoBehaviour
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
        if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
            ame.SetBool("isSliding", true);
            }
        else ame.SetBool("isSliding", false);

     
        }
    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "CollectibleLaser" && ame.GetBool("isSliding"))
            {
            Destroy(collision.gameObject);
            GetComponent<TutorialAmmoScript>().ChangeAmmo(1);
            }
        }
    }

