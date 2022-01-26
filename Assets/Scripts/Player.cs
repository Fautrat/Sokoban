using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody rbody;
    public Vector3 moveInput = Vector3.zero;
    private Animator animator;
    private SkinnedMeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GameObject.Find("character").GetComponent<Animator>();
        mesh = GameObject.Find("character").GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = moveInput * speed;
        float speedX = Mathf.Abs(rbody.velocity.x);
        float speedZ = Mathf.Abs(rbody.velocity.z);
        animator.SetBool("isRunning" , false);
        if(speedX > 0 || speedZ > 0 )
        {
            animator.SetBool("isRunning" , true);
        }
        else
            animator.SetBool("isRunning" , false);
    }

    public void PlayerMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector3>();
        moveInput = moveInput.normalized;
        
        /* gestion de la rotation du personnage */
        if(moveInput.x > 0.0f)
            if(moveInput.z > 0.0f)
                transform.rotation = Quaternion.LookRotation(new Vector3(-0.5f,0,0.5f));
            else if(moveInput.z < 0.0f)
                transform.rotation = Quaternion.LookRotation(new Vector3(0.5f,0,0.5f));
            else
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
        else if(moveInput.x < 0.0f)
            if(moveInput.z > 0.0f)
                transform.rotation = Quaternion.LookRotation(new Vector3(-0.5f,0,-0.5f));
            else if(moveInput.z < 0.0f)
                transform.rotation = Quaternion.LookRotation(new Vector3(0.5f,0,-0.5f));
            else
                transform.rotation = Quaternion.LookRotation(-Vector3.forward);
        else if(moveInput.z > 0.0f)
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        else if(moveInput.z < 0.0f)
            transform.rotation = Quaternion.LookRotation(-Vector3.left);
    }

    public void UndoMovement(Vector3 newPos)
    {
        transform.position = newPos;
    }
}
