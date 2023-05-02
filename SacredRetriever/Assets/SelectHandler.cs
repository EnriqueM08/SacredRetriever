using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectHandler : MonoBehaviour
{
    public EventSystem ev;
    public GameObject KnightSelect;
    public GameObject WizardSelect;
    // Start is called before the first frame update

    void Start() {
        if(PlayerPrefs.GetString("selectedChar").Equals("Wizard")) {
            KnightSelect.GetComponent<Image>().color = new Color32(19, 230, 236, 255);
            WizardSelect.GetComponent<Image>().color = new Color32(115, 118, 118, 255);
        }
        else {
            KnightSelect.GetComponent<Image>().color = new Color32(115, 118, 118, 255);
            WizardSelect.GetComponent<Image>().color = new Color32(19, 230, 236, 255);
        }
    }
    public void selectKnight() {
        PlayerPrefs.SetString("selectedChar", "Knight");
        KnightSelect.GetComponent<Image>().color = new Color32(115, 118, 118, 255);
        WizardSelect.GetComponent<Image>().color = new Color32(19, 230, 236, 255);
    }

    public void selectWizard() {
        PlayerPrefs.SetString("selectedChar", "Wizard");
        KnightSelect.GetComponent<Image>().color = new Color32(19, 230, 236, 255);
        WizardSelect.GetComponent<Image>().color = new Color32(115, 118, 118, 255);
    }

    public void returnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
