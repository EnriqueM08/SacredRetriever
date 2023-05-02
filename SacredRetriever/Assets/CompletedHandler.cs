using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompletedHandler : MonoBehaviour
{
    public Text txt;
    void Start() {
        txt.text = "Congratulations you completed level " + PlayerPrefs.GetInt("curLevel") + "!";
    }
    public void ReturnToMenu(){
        if(PlayerPrefs.GetInt("level") != 3) {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("curLevel") + 1);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        if(PlayerPrefs.GetInt("level") != 3) {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("curLevel") + 1);
        }
        Application.Quit();
    }
}
