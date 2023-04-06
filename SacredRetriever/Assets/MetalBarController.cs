using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBarController : MonoBehaviour
{
    public block aBlock;
    public block bBlock;
    public block cBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aBlock.GetComponent<block>().inPlace && bBlock.GetComponent<block>().inPlace && cBlock.GetComponent<block>().inPlace)
        {
            Destroy(gameObject);
        }
    }
}
