using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;

    void Start() {
        
    }

    void Update() {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
