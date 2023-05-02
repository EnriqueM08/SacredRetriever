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
    public GameObject[] blobSpawners;
    public GameObject backwardsDoor;
    GameObject metalBars;
    public Canvas pauseMenu;
    public Canvas optionsMenu;
    public static bool isPaused;
    private GameObject[] spawnTorches;
    private GameObject[] puzzleTorches;
    private bool allSpawnersDestroyed = false;
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
        spawnTorches = GameObject.FindGameObjectsWithTag("SpawnerTorches");
        puzzleTorches = GameObject.FindGameObjectsWithTag("PuzzleTorches");
        foreach (GameObject torch in spawnTorches) {
            torch.SetActive(false);
        }
        foreach (GameObject torch in puzzleTorches) {
            torch.SetActive(false);
        }
        blobSpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCharacter.isDead)
        {
            SceneManager.LoadScene("DeathScreen");
        }
        allSpawnersDestroyed = true;
        foreach(GameObject spawner in blobSpawners) {
            if(!spawner.GetComponent<Spawner>().isDestroyed) {
                allSpawnersDestroyed = false;
            }
        }
        if(allSpawnersDestroyed) {
            foreach (GameObject torch in spawnTorches) {
                torch.SetActive(true);
            }
        }
        if(aBlock.GetComponent<block>().inPlace && bBlock.GetComponent<block>().inPlace && cBlock.GetComponent<block>().inPlace) {
            foreach (GameObject torch in puzzleTorches) {
                torch.SetActive(true);
            }
        }
        if(aBlock.GetComponent<block>().inPlace && bBlock.GetComponent<block>().inPlace && cBlock.GetComponent<block>().inPlace && allSpawnersDestroyed)
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
    }

    public void PauseGame() {
        ShowPauseMenu();
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
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
        optionsMenu.enabled = false;
    }
}
