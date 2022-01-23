using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject victoryMessage;
    void Start() 
    {
        victoryMessage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        bool isWin = true;
        foreach (Activate slot in this.GetComponentsInChildren<Activate>())
        {
            if(!slot.isActivated)
            {
                isWin = false;
            }
        }

        if(isWin) 
            victoryMessage.SetActive(true);
    }
}
