using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
            isActivated = true;
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Block")
            isActivated = false;
    }
}
