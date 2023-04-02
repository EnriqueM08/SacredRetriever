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
        
    }

    void update() {
        if(character.transform.position.x <= 12.5f)
            StartCoroutine(GenerateBlobs());  
        else
            StopAllCoroutines();
    }

    IEnumerator GenerateBlobs() {
        while(true) {
            Vector2 randomPosition = new Vector2(Random.Range(-22f,-15f),Random.Range(-4.5f, 4.5f));
            yield return new WaitForSeconds(2f);
            GameObject newBlob = Instantiate(BlobPrefab, randomPosition, Quaternion.identity);
            Destroy(gameObject, 60);
        }
    }
}
