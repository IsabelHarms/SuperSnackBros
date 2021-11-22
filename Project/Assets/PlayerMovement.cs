using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 10.0f;
    public float jumpSpeed = 10f;
    
    private CharacterController characterController;
    private float zSpeed;
    private float originalStepOffset;

    //Start is called vefore the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        
    }

    // Update is called once per frame
    // Get input from player
    void Update()
    {


        float yDirection = 0.0f;
        float xDirection = Input.GetAxis("Horizontal");    //Controlling the x axis -- a = -<; d = 1;
        //float yDirection = Input.GetAxis("Vertical");      // Controlling the z axis 

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, yDirection);
        float magnitude = Mathf.Clamp01(moveDirection.magnitude) * movementSpeed;
        moveDirection.Normalize();

        zSpeed += 2*Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            zSpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                zSpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        // turn left
        if(Input.GetKey("a") && transform.rotation!=Quaternion.Euler(0,-90,0))
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }
        //turn right
        if(Input.GetKey("d") && transform.rotation!=Quaternion.Euler(0,90,0))
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }

        /*
        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        */

        Vector3 velocity = moveDirection * magnitude;
        velocity.y = zSpeed;
        characterController.Move(velocity * Time.deltaTime);

    }
}
