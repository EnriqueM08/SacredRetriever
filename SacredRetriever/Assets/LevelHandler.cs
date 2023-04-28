using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public GameObject KnightPrefab;
    public GameObject WizardPrefab;
    public Character mainCharacter;
    public block aBlock;
    public block bBlock;
    public block cBlock;
    public Spawner blobSpawner;
    public GameObject backwardsDoor;
    GameObject metalBars;
    public Canvas pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp;
        if(PlayerPrefs.GetString("selectedChar").Equals("Wizard"))
        {
            temp = GameObject.Instantiate(WizardPrefab);
        }
        else
            temp = GameObject.Instantiate(KnightPrefab);
        temp.transform.position = new Vector3(1.507f, -5.524f, 0);
        mainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        metalBars = GameObject.Find("MetalBars");
        pauseMenu.enabled = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCharacter.isDead)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if(aBlock.GetComponent<block>().inPlace && bBlock.GetComponent<block>().inPlace && cBlock.GetComponent<block>().inPlace && blobSpawner.GetComponent<Spawner>().isDestroyed)
        {
            Destroy(metalBars);
        }
        if(mainCharacter.GetComponent<Character>().hasTreasure)
        {
            Destroy(backwardsDoor.GetComponent<BoxCollider2D>());
        }
        if(mainCharacter.transform.position.y < -5.8f) {
            SceneManager.LoadScene("Completed");
        }
        // if(Input.GetKeyDown(KeyCode.Escape)) {
        //     PauseGame();
        // }
    }

    public void PauseGame() {
        ShowPauseMenu();
        isPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    void ShowPauseMenu() {
        pauseMenu.enabled = true;
    }
}
