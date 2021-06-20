using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.localScale.x>0) transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 7, -10);
        else transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 7, -10);

        }
    }
