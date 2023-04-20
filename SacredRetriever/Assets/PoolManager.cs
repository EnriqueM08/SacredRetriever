using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int defaultPoolSize = 10;
    public GameObject BlobPrefab;
    private List<GameObject> enemyPool = new List<GameObject>();
    

    void Start()
    {
        GenerateBlobs(defaultPoolSize);
    }
    public GameObject RequestEnemy() {
        foreach(GameObject enemy in enemyPool) {
            if(enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(BlobPrefab);
        enemyPool.Add(newEnemy);

        return newEnemy;
    }

    public void DespawnEnemy(GameObject enemy) {
        enemy.SetActive(false);
    }

    List<GameObject> GenerateBlobs(int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject enemy = Instantiate(BlobPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
        return enemyPool;
    }
}
