using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     //if(other.gameObject.tag == "correct")
    //     //TODO: DO SOMETHING
    // }
}
