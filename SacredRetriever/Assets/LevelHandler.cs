using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public Character mainCharacter;
    public block aBlock;
    public block bBlock;
    public block cBlock;
    public Spawner blobSpawner;
    public GameObject backwardsDoor;
    GameObject metalBars;

    // Start is called before the first frame update
    void Start()
    {
        metalBars = GameObject.Find("MetalBars");
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
    }
}
