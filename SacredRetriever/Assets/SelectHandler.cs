using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectHandler : MonoBehaviour
{
    public EventSystem ev;
    public GameObject KnightSelect;
    public GameObject WizardSelect;
    // Start is called before the first frame update

    void Start() {
        if(PlayerPrefs.GetString("selectedChar").Equals("Wizard"))
            ev.firstSelectedGameObject = WizardSelect;
        else
            ev.firstSelectedGameObject = KnightSelect;
    }
    public void selectKnight() {
        PlayerPrefs.SetString("selectedChar", "Knight");
    }

    public void selectWizard() {
        PlayerPrefs.SetString("selectedChar", "Wizard");
    }

    public void returnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
