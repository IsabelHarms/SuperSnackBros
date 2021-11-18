using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNinjaController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float speedForward;
    [SerializeField] private float speedBackward;

    public Animator animator;
    public LayerMask layerMask;
    private Rigidbody rb;
    public bool grounded;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        Grounded();
        Jump();
        Move();
        
        Punch();
        Kick();
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }

    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;
        }
        else 
        {
            this.grounded = false;
        }
        this.animator.SetBool("jump", !this.grounded);
    }

    private void Move()
    {
        float horizontalAxis = -Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.right * horizontalAxis;
        movement.Normalize();


        this.moveSpeed = horizontalAxis > 0 ? speedForward : speedBackward; 

        this.transform.position += movement * this.moveSpeed;

        this.animator.SetFloat("horizontal", horizontalAxis);
    }

    private void Punch()
    {
        if (Input.GetMouseButton(0))
        {
            this.animator.SetTrigger("punch_two");
        } 
        else 
        {
            this.animator.ResetTrigger("punch_two");
        }
    }

    private void Kick()
    {
        if (Input.GetMouseButton(1) && !this.animator.GetBool("kick_1"))
        {
            this.animator.SetBool("kick_1", true);
        } else {
            this.animator.SetBool("kick_1", false);
        }

        if (Input.GetMouseButton(1) && this.animator.GetBool("kick_1"))
        {
            Debug.Log("KICK 2");
            this.animator.SetBool("kick_2", true);
        } else {
            this.animator.SetBool("kick_2", false);
        }
        
    }


    
    private void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) 
    {
        Debug.Log("OnStateEnter");
        this.animator.ResetTrigger("kick_one");
    }

}

