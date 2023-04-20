using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlobs : MonoBehaviour
{
    public GameObject character;
    private List<GameObject> enemyPool = new List<GameObject>();
    private bool inRange = false;
    public PoolManager PoolManager;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnBlob());
    }

    void Update() {
        if(character.transform.localPosition.x <= -12.5f) {
            inRange = true;
        }
        else {
            inRange = false;
        }
    }

    IEnumerator SpawnBlob() {
        while(true) {
            if(inRange) {
                Vector2 randomPosition = new Vector2(Random.Range(-21f,-20f),Random.Range(5f, 6f));
                GameObject newBlob = PoolManager.RequestEnemy();
                newBlob.transform.position = randomPosition;
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
