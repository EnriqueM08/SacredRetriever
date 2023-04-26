using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    public Canvas options;
    public Canvas pause;
    // Start is called before the first frame update
    void Start()
    {
        options.enabled = false;
    }

    public void Options() {
        pause.enabled = false;
        options.enabled = true;
    }

    public void exitGame() {
        Application.Quit();
    }

    public void returnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitOptions() {
        options.enabled = false;
        pause.enabled = true;
    }
}
