using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattryLife : MonoBehaviour
{
    public float life;
     Text battery;

    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        battery = GameObject.Find("BatteryLife").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        battery.text =((int)life).ToString();
        
    }
    public void changeBattery(float addition) 
    {
        life += addition;
        

    }
}
