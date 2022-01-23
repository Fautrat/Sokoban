using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody rbody;
    public Vector3 moveInput;
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
        //Debug.Log(rbody.velocity.x);
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

    public void playerMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector3>();
        rbody.velocity = moveInput * speed;
    }
}
