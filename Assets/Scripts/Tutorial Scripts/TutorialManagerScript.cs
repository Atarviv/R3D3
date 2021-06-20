using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManagerScript : MonoBehaviour
{
    public GameObject Goblin;
    GameObject[] Batteries;
    GameObject[] Lasers;
    public GameObject BatteryPrefab;
    public GameObject LaserPrefab;
    public GameObject LaserText;
    public GameObject player;
    [Header("Panels")]
    public GameObject MovingPanel;
    public GameObject JumpingPanel;
    public GameObject ShootingPanel;
    public GameObject CollectBatteryPanel;
    public GameObject CollectLasersPanel;
    public GameObject KillGoblinsPanel;
    public GameObject Level3GoblinPanel;
    public GameObject StartTheGamePanel;
    public GameObject YouDiedPanel;
    public GameObject batteryText;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        MovingPanel.gameObject.SetActive(true);
        player.GetComponent<TutorialPlayerMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<TutorialBatteryScript>().BatteryLife == 0&&!gameOver)
            {
            player.GetComponent<TutorialPlayerMovementWithBattery>().enabled = false;
            player.GetComponent<TutorialPlayerJump>().enabled = false;
            player.GetComponent<TutorialPlayerSlide>().enabled = false;
            player.GetComponent<TutorialPlayerShoot>().enabled = false;
            player.GetComponent<Animator>().SetTrigger("IsDead");
            GameObject.FindGameObjectWithTag("Goblin").GetComponent<TutorialGoblinMovement>().DontMove = true;
            YouDiedPanel.gameObject.SetActive(true);
            gameOver = true;
            }
        }
    public void GoblinDied()
        {
        Level3GoblinPanel.gameObject.SetActive(false);
        StartTheGamePanel.gameObject.SetActive(true);
        }
    public void movingCleared()
        {
        MovingPanel.gameObject.SetActive(false);
        JumpingPanel.gameObject.SetActive(true);
        player.GetComponent<TutorialPlayerJump>().enabled = true;
        }
    public void jumpingCleared()
        {
        JumpingPanel.gameObject.SetActive(false);
        ShootingPanel.gameObject.SetActive(true);
        player.GetComponent<TutorialPlayerShoot>().enabled = true;
        }
    public void ShootingCleared()
        {
        ShootingPanel.gameObject.SetActive(false);
        CollectBatteryPanel.gameObject.SetActive(true);
        batteryText.gameObject.SetActive(true);
        for (int i = -270; i <= 550; i += 20)
            {
            Instantiate(BatteryPrefab, new Vector2(i, 5), player.transform.rotation);
            }
        player.GetComponent<TutorialBatteryScript>().enabled = true;
        player.GetComponent<TutorialPlayerMovement>().enabled = false;
        player.GetComponent<TutorialPlayerMovementWithBattery>().enabled = true;
        }
    public void BatteryCleared()
        {
        CollectBatteryPanel.gameObject.SetActive(false);
        CollectLasersPanel.gameObject.SetActive(true);
        player.GetComponent<TutorialPlayerSlide>().enabled = true;
        for (int i = -260; i <= 550; i += 40)
            {
            Instantiate(LaserPrefab, new Vector2(i, 2), player.transform.rotation);
            }
        player.GetComponent<TutorialAmmoScript>().enabled = true;
        LaserText.gameObject.SetActive(true);
        }
    public void LaserCollectionCleared()
        {
        CollectLasersPanel.gameObject.SetActive(false);
        KillGoblinsPanel.gameObject.SetActive(true);
        }
    public void KillGoblinCleared()
        {
        KillGoblinsPanel.gameObject.SetActive(false);
        Level3GoblinPanel.gameObject.SetActive(true);
        Instantiate(Goblin, new Vector2(player.transform.position.x + 30, player.transform.position.y), player.transform.rotation);
        }
    public void TryAgain()
        {
        SceneManager.LoadScene("Tutorial");

        }
    public void startTheGame()
        {
        SceneManager.LoadScene("Level1");
        }
}
