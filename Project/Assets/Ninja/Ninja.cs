using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public Animator animator;
    public LayerMask layerMask;
    private Rigidbody rb;
    public bool grounded;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        Grounded();
        Jump();
        Move();
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
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.04f;

        this.animator.SetFloat("vertical", verticalAxis);
        this.animator.SetFloat("horizontal", horizontalAxis);

    }

}
