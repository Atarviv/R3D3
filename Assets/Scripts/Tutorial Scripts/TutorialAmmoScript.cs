using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialAmmoScript : MonoBehaviour
{
    public int AmmoLife;
    public Text AmmoText;
    // Start is called before the first frame update
    void Start()
        {
        AmmoLife = 100;
        }

    // Update is called once per frame
    void Update()
        {
        AmmoText.text = (AmmoLife).ToString();
        }
    public void ChangeAmmo(int addition)
        {
        AmmoLife += addition;
        }
    }
