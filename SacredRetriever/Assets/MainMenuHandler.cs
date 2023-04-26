using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public Canvas options;
    public Canvas keyBinds;
    public GameObject mainMenu;
    public void Start()
    {
        options.enabled = false;
        keyBinds.enabled = false;
    }
    public void StartGame(){
        SceneManager.LoadScene("Level1");
    }
    
    public void Options(){
        options.enabled = true;
    }

    public void ExitOptions(){
        options.enabled = false;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
