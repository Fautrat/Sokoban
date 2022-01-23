using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private Vector3 move;
    private Vector3 position;

    public Vector3 lastPos;

    public Vector3 lastPosPlayer;

    void Start()
    {
        lastPos = new Vector3(0.0f, 0.0f, .0f);
    }
    void OnCollisionEnter(Collision other) 
    {
        move = other.collider.GetComponent<Player>().moveInput;
        position = new Vector3();
        if (move.x == 1.0f && transform.position.x < 15.0f)
        {
            lastPos = transform.position;
            position.x += 4.0f;
        }   
        else if (move.x == -1.0f && transform.position.x > -16.0f)
        {
            lastPos = transform.position;
            position.x -= 4.0f;
        }
        else if(move.z == 1.0f && transform.position.z < 16.0f)
        {
            lastPos = transform.position;
            position.z += 4.0f;
        }
            
        else if(move.z == -1.0f && transform.position.z > -16.0f)
        {
            lastPos = transform.position;
            position.z -= 4.0f;
        }

        transform.Translate(position);
    }

}
