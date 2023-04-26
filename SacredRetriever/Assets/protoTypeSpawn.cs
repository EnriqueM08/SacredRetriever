using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protoTypeSpawn : MonoBehaviour
{
    //public blab blabProtoType;
    public Blub blubProto;
    public int maxHealth = 200;
    public GameObject character;
    private bool inRange = false;
    int currentHealth;
    public bool isDestroyed = false;
    public bool fixing;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        character = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Spawn());
    }

    void Update() {
        if(character.transform.localPosition.x <= -12.5f) {
            inRange = true;
        }
        else {
            inRange = false;
        }
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

    IEnumerator Spawn() {
        while(true) {
            if(inRange) {
                Vector2 randomPosition = new Vector2(Random.Range(-21f,-20f),Random.Range(5f, 6f));
                //GameObject newEnemy = blabProtoType.spawn();
                GameObject newEnemy2 = blubProto.spawn();
                //newEnemy.transform.position = randomPosition;
                newEnemy2.transform.position = randomPosition;
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
