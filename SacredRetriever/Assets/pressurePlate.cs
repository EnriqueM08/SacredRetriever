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
        if(other.gameObject.tag == "Player" && (!aBlock.GetComponent<block>().inPlace || !bBlock.GetComponent<block>().inPlace || !cBlock.GetComponent<block>().inPlace)) {
            aBlock.transform.position = aLoc;
            bBlock.transform.position = bLoc;
            cBlock.transform.position = cLoc;
            aBlock.GetComponent<block>().inPlace = false;
            bBlock.GetComponent<block>().inPlace = false;
            cBlock.GetComponent<block>().inPlace = false;
            Rigidbody2D a = aBlock.GetComponent<Rigidbody2D>();
            Rigidbody2D b = bBlock.GetComponent<Rigidbody2D>();
            Rigidbody2D c = cBlock.GetComponent<Rigidbody2D>();
            a.velocity = Vector3.zero;
            b.velocity = Vector3.zero;
            c.velocity = Vector3.zero;
            a.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            a.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            a.constraints = RigidbodyConstraints2D.FreezeRotation;
            b.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            b.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            b.constraints = RigidbodyConstraints2D.FreezeRotation;
            c.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            c.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            c.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
