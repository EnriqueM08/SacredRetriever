using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyOptions : MonoBehaviour
{
    public Dropdown difficultyDropDown;

    void Start()
    {
        if(PlayerPrefs.GetInt("difficultySet") == 0) {
            PlayerPrefs.SetInt("difficultySet", 1);
            PlayerPrefs.SetInt("difficulty",  0);
            difficultyDropDown.value = 0;
        } 
        switch (PlayerPrefs.GetInt("difficulty"))
        {
                case 0:
                    difficultyDropDown.value = 0;
                    break;
                case 1:
                    difficultyDropDown.value = 1;
                    break;
                case 2:
                    difficultyDropDown.value = 2;
                    break;
                case 3:
                    difficultyDropDown.value = 3;
                    break;
        }
    }

    public void SetDiffculty()
    {
       PlayerPrefs.SetInt("difficulty", difficultyDropDown.value);
    }
}
