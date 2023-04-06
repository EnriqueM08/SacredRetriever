using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlobs : MonoBehaviour
{
    public GameObject BlobPrefab;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenerateBlobs"); 
    }

    void update() {
        //if(character.transform.position.x <= 12.5f)
             
        //else
          //  StopAllCoroutines();
    }

    IEnumerator GenerateBlobs() {
        while(true) {
            Vector2 randomPosition = new Vector2(Random.Range(-21f,-20f),Random.Range(5f, 6f));
            yield return new WaitForSeconds(3f);
            GameObject newBlob = Instantiate(BlobPrefab, randomPosition, Quaternion.identity);
            //Destroy(gameObject, 60);
        }
    }
}
