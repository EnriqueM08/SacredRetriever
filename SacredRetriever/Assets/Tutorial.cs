using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Character mainCharacter;
    public Text tutorialTxt;
    public Spawner spawn;
    public block aBlock;
    public block bBlock;
    public block cBlock;
    public GameObject tutorialBar;
    bool unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCharacter == null)
        {
            mainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        }
        if(mainCharacter.transform.position.x != 1.507f) {
            if(!mainCharacter.firstAttack)
                tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Press space to attack!";
            else {
                tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Select a path, left or right, to begin your journey!";
            }
        }
        if(mainCharacter.transform.position.x <= -12.5f && !spawn.isDestroyed) {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Defeat enemies and destroy all spawners!";
        }
        if(spawn.currentHealth < spawn.maxHealth && !spawn.isDestroyed)
        {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Continue hitting spawner to destroy it!";
        }
        if(spawn.isDestroyed && !mainCharacter.recovered) {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Collect blue drops to recover health!";
        }
        if(spawn.isDestroyed && mainCharacter.recovered && !unlocked) {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Torches light up blue once a room is completed! Head to the right side!";
        }
        if(mainCharacter.transform.position.x >= 14.5f && (!aBlock.GetComponent<block>().inPlace || !bBlock.GetComponent<block>().inPlace || !cBlock.GetComponent<block>().inPlace)) {
             tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Push blocks into matching holes! Use pressure plate to reset!";
        }
        if(mainCharacter.inFire) {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Avoid fire or you will take damage!";
        }
        if(aBlock.GetComponent<block>().inPlace && bBlock.GetComponent<block>().inPlace && cBlock.GetComponent<block>().inPlace && !spawn.isDestroyed) {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Torches light up blue once a room is completed! Head to the left side!";
        }
        if(aBlock.GetComponent<block>().inPlace && bBlock.GetComponent<block>().inPlace && cBlock.GetComponent<block>().inPlace && spawn.isDestroyed) {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Bars unlocked return to main area to get treasure!";
            unlocked = true;
        }
        if(unlocked && mainCharacter.transform.position.x > -12.5f && mainCharacter.transform.position.x < 14.5f) {
            tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Head up and grab treasure!";
            if(mainCharacter.hasTreasure) {
                 tutorialTxt.GetComponent<UnityEngine.UI.Text>().text = "Go down through door at start to complete level!";
            }
        }
    }

    public void SkipTutorial() {
        tutorialBar.SetActive(false);
    }
}
