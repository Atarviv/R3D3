using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserForce : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    public void Awake()
    {
        player = GameObject.Find("Robot");
        if(player.transform.localScale.x >0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(3000, 0));
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-3000, 0));
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Roobot") Destroy(gameObject);
        }
    public void OnTriggerEnter2D(Collider2D other)
        {
        if(other.gameObject.name!="Roobot") Destroy(gameObject);
        }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
