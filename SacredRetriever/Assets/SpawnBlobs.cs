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
        StartCoroutine(SpawnBlob());
    }

    void Update() {
        if(character == null)
            character = GameObject.FindGameObjectWithTag("Player");
        if(character.transform.localPosition.x - gameObject.GetComponent<Transform>().localPosition.x < 3 && character.transform.localPosition.x - gameObject.GetComponent<Transform>().localPosition.x > -3) {
            if(character.transform.localPosition.y - gameObject.GetComponent<Transform>().localPosition.y < 3 && character.transform.localPosition.y - gameObject.GetComponent<Transform>().localPosition.y > -3)
            inRange = true;
        }
        else {
            inRange = false;
        }
    }

    IEnumerator SpawnBlob() {
        while(true) {
            if(inRange) {
                Vector2 randomPosition = new Vector2(Random.Range(gameObject.GetComponent<Transform>().localPosition.x-1,gameObject.GetComponent<Transform>().localPosition.x+1),Random.Range(gameObject.GetComponent<Transform>().localPosition.y-0.5f, gameObject.GetComponent<Transform>().localPosition.y));
                GameObject newBlob = PoolManager.RequestEnemy();
                newBlob.transform.position = randomPosition;
            }
            switch (PlayerPrefs.GetInt("difficulty"))
            {
                case 0:
                    yield return new WaitForSeconds(3f);
                    break;
                case 1:
                    yield return new WaitForSeconds(2f);
                    break;
                case 2:
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 3:
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
}
