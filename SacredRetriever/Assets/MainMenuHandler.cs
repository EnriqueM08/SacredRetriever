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
        if(PlayerPrefs.GetInt("level") == 0) {
            PlayerPrefs.SetInt("level", 1);
        }
    }
    public void StartGame(){
        SceneManager.LoadScene("LevelSelector");
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

    public void switchToCharSelect() {
        SceneManager.LoadScene("CharacterSelector");
    }
}
