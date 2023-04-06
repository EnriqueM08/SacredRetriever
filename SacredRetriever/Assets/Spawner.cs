using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int maxHealth = 200;
    int currentHealth;
    public bool isDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        if(currentHealth <= 0)
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        Debug.Log("Spawner destoryed!");
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject.GetComponent<SpawnBlobs>());
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        isDestroyed = true;
    }
}
