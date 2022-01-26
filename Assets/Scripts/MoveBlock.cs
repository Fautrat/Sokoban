using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private Vector3 move;
    private Vector3 position;
    private Vector3 velocity;
    private Rigidbody rbody;
    private List<Vector3> listInputs = new List<Vector3>();

    private Vector3 goal;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        move = Vector3.zero;
        goal = transform.position;
    }

    void Update()
    {
        rbody.velocity = velocity;

        if(transform.position.x < goal.x + 0.1f && transform.position.x > goal.x -0.1f && transform.position.z < goal.z + 0.1f && transform.position.z > goal.z -0.1f)
            rbody.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision other) 
    {
        GameObject collider = other.gameObject;
        if(collider.tag ==  "Player")
        {
            move = collider.GetComponent<Player>().moveInput;

            if (move.x == 1.0f && transform.position.x < 15.0f)
            {
                goal = transform.position;
                goal.x += 4;
                velocity = new Vector3(10.0f,.0f,.0f);
            }   
            else if(move.x == -1.0f && transform.position.x > -15.0f)
            {
                goal = transform.position;
                goal.x = goal.x - 4.0f;
                velocity = new Vector3(-10.0f,.0f,.0f);
            }
            else if(move.z == 1.0f && transform.position.z < 15.0f)
            {
                goal = transform.position;
                goal.z = goal.z + 4.0f;
                velocity = new Vector3(0.0f,.0f,10.0f);
            }
            else if(move.z == -1.0f && transform.position.z > -15.0f)
            {
                goal = transform.position;
                goal.z = goal.z - 4.0f;
                velocity = new Vector3(0.0f,.0f,-10.0f);
            }

            if (velocity != Vector3.zero)
            {
                listInputs.Add(move);
                GameObject.Find("Canvas").GetComponent<GameManager>().listAllMovements.Add(this);
            }
        }

    }

    public void UndoLastMove()
    {
        move = listInputs[listInputs.Count-1];
        Vector3 newPlayerPos = Vector3.zero; 

        if (move.x == 1.0f)
            {
                goal = transform.position;
                goal.x = goal.x - 4.0f;
                velocity = new Vector3(-10.0f,.0f,.0f);
                newPlayerPos.x = goal.x - 3.0f;
                newPlayerPos.z = goal.z;
            }   
            else if(move.x == -1.0f)
            {
                goal = transform.position;
                goal.x = goal.x + 4.0f;
                velocity = new Vector3(10.0f,.0f,.0f);
                newPlayerPos.x = goal.x + 3.0f;
                newPlayerPos.z = goal.z;
            }
            else if(move.z == 1.0f)
            {
                goal = transform.position;
                goal.z = goal.z - 4.0f;
                velocity = new Vector3(0.0f,.0f,-10.0f);
                newPlayerPos.x = goal.x ;
                newPlayerPos.z = goal.z - 3.0f;
            }
            else if(move.z == -1.0f)
            {
                goal = transform.position;
                goal.z = goal.z + 4.0f;
                velocity = new Vector3(0.0f,.0f,10.0f);
                newPlayerPos.x = goal.x;
                newPlayerPos.z = goal.z + 3.0f;
            }
        listInputs.RemoveAt(listInputs.Count - 1);
        
        GameObject.Find("Player").GetComponent<Player>().UndoMovement(newPlayerPos);
    }

}
