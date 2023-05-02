using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectHandler : MonoBehaviour
{
    public void level1() {
        PlayerPrefs.SetInt("curLevel", 1);
        SceneManager.LoadScene("Level1");
    }

    public void level2() {
        PlayerPrefs.SetInt("curLevel", 2);
        SceneManager.LoadScene("Level2");
    }

    public void level3() {
        PlayerPrefs.SetInt("curLevel", 3);
        SceneManager.LoadScene("Level3");
    }

    public void goBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
