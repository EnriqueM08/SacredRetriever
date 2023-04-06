using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    Vector3 originalPos;
    Rigidbody2D rb;
    public bool inPlace = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "BlueKey" && this.gameObject.tag == "BlueBlock")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            inPlace = true;
        }
        else if(other.gameObject.tag == "PurpleKey" && this.gameObject.tag == "PurpleBlock") {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            inPlace = true;
        }
        else if(other.gameObject.tag == "YellowKey" && this.gameObject.tag == "YellowBlock") {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            inPlace = true;
        }
    }
}
