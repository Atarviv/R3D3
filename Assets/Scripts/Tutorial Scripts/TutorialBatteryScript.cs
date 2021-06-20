using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBatteryScript : MonoBehaviour
{

    public float BatteryLife;
    public Text BatteryText;
    // Start is called before the first frame update
    void Start()
    {
        BatteryLife = 100;
    }

    // Update is called once per frame
    void Update()
    {
        BatteryLife = Mathf.Clamp(BatteryLife, 0, 100);
        BatteryText.text = ((int)BatteryLife).ToString();
    }
    public void ChangeBattery(float addition)
        {
        BatteryLife += addition;
        }
    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "Goblin")
            {
            ChangeBattery(-15);
            }
        }
    }
