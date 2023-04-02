using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public int maxHealth = 20;
    int currentHealth;
    public Animator animator;
    

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
        Debug.Log("Enemy died!");
        animator.Play("BlobDeath");
        yield return new WaitForSeconds(.05f);
        GameObject parent = this.transform.parent.gameObject;
        Destroy(parent);
        Destroy(this);
    }
}

