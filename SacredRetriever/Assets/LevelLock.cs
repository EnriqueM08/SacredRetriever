using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    [SerializeField] int levelRequirement;
    void Start(){
        int currentLevel = PlayerPrefs.GetInt("level");
        bool levelUnlocked = currentLevel >= levelRequirement;
        gameObject.GetComponent<Button>().interactable = levelUnlocked;
    }
}
