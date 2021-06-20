using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBarScript : MonoBehaviour
{
    float StartingWidth, StartingX,lostBattery;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        StartingX = transform.position.x;
        StartingWidth = GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        lostBattery = 100 - Player.GetComponent<TutorialBatteryScript>().BatteryLife;
        GetComponent<Image>().rectTransform.sizeDelta = new Vector2(StartingWidth - StartingWidth * lostBattery / 100, GetComponent<RectTransform>().rect.height);
        transform.position = new Vector2(StartingX + (StartingWidth * lostBattery / 100), transform.position.y);
    }
}
