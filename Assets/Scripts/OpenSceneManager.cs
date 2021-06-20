using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneManager : MonoBehaviour
    {
    // Start is called before the first frame update
    public void GotoAbout()
        {
        SceneManager.LoadScene("About");
        }
    public void StartTutorial()
        {
        SceneManager.LoadScene("Tutorial");
        }
    public void StartGame()
        {
        SceneManager.LoadScene("Level1");
        }
    public void ReturnToStart()
        {
        SceneManager.LoadScene("OpenScene");
        }
}
