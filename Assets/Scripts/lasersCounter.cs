using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lasersCounter : MonoBehaviour
{
    public int MyLasers;
    Text lasers;

    // Start is called before the first frame update
    void Start()
    {
        MyLasers = 50;
        lasers = GameObject.Find("Lasers").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lasers.text = (MyLasers).ToString();

    }
    public void LaserCount(int addition)
    {
        MyLasers += addition;


    }

}