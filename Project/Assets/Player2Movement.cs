using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed;
    public float jumpSpeed;

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
    void Update()
    {
        float yDirection = 0.0f;
        float xDirection = Input.GetAxis("Horizontal");    //Controlling the x axis
        //float yDirection = Input.GetAxis("Vertical");      // Controlling the z axis 

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, yDirection);
        float magnitude = Mathf.Clamp01(moveDirection.magnitude) * speed;
        moveDirection.Normalize();

        zSpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            zSpeed = -0.5f;

            if (Input.GetButtonDown("Up"))
            {
                zSpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = moveDirection * magnitude;
        velocity.y = zSpeed;
        characterController.Move(velocity * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }




    }
}
