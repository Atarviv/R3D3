using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject GameOverPanel;
    public float speed;
    public bool isground;
    Animator ame;
    public GameObject Laser;
    public Transform Firepos;
    bool gameRunning;
    // Start is called before the first frame update
    void Start()
    {
        isground = true;
        ame = GetComponent<Animator>();
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BattryLife>().life <= 0&&gameRunning) Die();
        if (gameRunning)
            {
            if (Input.GetKeyDown(KeyCode.Space) && GetComponent<lasersCounter>().MyLasers > 0)
                {
                ame.SetBool("isShooting", true);
                }
            else
                {
                ame.SetBool("isShooting", false);
                }
            if (Input.GetKey(KeyCode.UpArrow) == true && isground == true)
                {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
                isground = false;
                ame.SetBool("isJumping", true);
                }
            else if (Input.GetKey(KeyCode.RightArrow) == true)
                {
                transform.localScale = new Vector2(1, 1);
                transform.Translate(speed*Time.deltaTime, 0, 0);
                ame.SetBool("isRunning", true);
                GetComponent<BattryLife>().changeBattery(-0.01f);
                }
            else if (Input.GetKey(KeyCode.LeftArrow) == true)
                {
                transform.localScale = new Vector2(-1, 1);
                transform.Translate(-speed*Time.deltaTime, 0, 0);
                ame.SetBool("isRunning", true);
                GetComponent<BattryLife>().changeBattery(-0.01f);
                }
            else
                {
                ame.SetBool("isRunning", false);
                }
            }
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ame.SetBool("isJumping", false);
            isground = true;

        }
        if (collision.gameObject.tag == "Goblin"&&gameRunning)
            {
            GetComponent<BattryLife>().changeBattery(collision.gameObject.GetComponent<GoblinMovement>().GoblinLevel * 5 * -1);
            }
    }
    public void shooting()
    {
        Instantiate(Laser, Firepos.position, Laser.transform.localRotation);
    }
    public void Die()
        {
        gameRunning = false;
        GameObject[] goblins = GameObject.FindGameObjectsWithTag("Goblin");
        for(int i = 0;i<goblins.Length; i++)
            {
            goblins[i].GetComponent<GoblinMovement>().DontMove = true;
            }
        ame.SetTrigger("IsDead");
        GameOverPanel.gameObject.SetActive(true);
        }
    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "Battery")
            {
            GetComponent<BattryLife>().changeBattery(+5);
            Destroy(collision.gameObject);

            }
        if (collision.gameObject.tag == "Laser")
            {
            GetComponent<lasersCounter>().LaserCount(+1);
            Destroy(collision.gameObject);
            }
        }
    }