using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    Vector3 aLoc, bLoc, cLoc;

    public GameObject aBlock;
    public GameObject bBlock;
    public GameObject cBlock;

    // Start is called before the first frame update
    void Start()
    {
        aLoc = aBlock.transform.position; 
        bLoc = bBlock.transform.position; 
        cLoc = cBlock.transform.position;
    }

     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            aBlock.transform.position = aLoc;
            bBlock.transform.position = bLoc;
            cBlock.transform.position = cLoc;
            Rigidbody2D a = aBlock.GetComponent<Rigidbody2D>();
            Rigidbody2D b = bBlock.GetComponent<Rigidbody2D>();
            Rigidbody2D c = cBlock.GetComponent<Rigidbody2D>();
            a.velocity = Vector3.zero;
            b.velocity = Vector3.zero;
            c.velocity = Vector3.zero;
        }
    }
}
