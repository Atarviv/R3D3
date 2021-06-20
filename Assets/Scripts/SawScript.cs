using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
            {
            if (transform.position.y < 15.5f) transform.Translate(0, 0.03f, 0);
            else up = false;
            }
        else
            {
            if (transform.position.y > -0.2f) transform.Translate(0, -0.03f, 0);
            else up = true;
            }
    }
}
