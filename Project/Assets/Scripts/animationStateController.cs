using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isCrouchingHash;

    public bool keyWalking;
    public bool keyCrouching;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isCrouchingHash = Animator.StringToHash("isCrouching");
        Debug.Log(animator);

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
// walking
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isCrouching = animator.GetBool(isCrouchingHash);


        if(Input.GetKey("a") || Input.GetKey("d"))
        {
            Debug.Log("move");
            keyWalking = true;
        }
        if(!(Input.GetKey("a") || Input.GetKey("d")))
        {
            keyWalking = false;
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("crouch");
            keyCrouching = true;
        }
        if(!Input.GetKey(KeyCode.LeftControl))
        {
            keyCrouching = false;
        }

        // WALKING
        // if player presses a key
        if (!isWalking && keyWalking)
        {
            // then set the isWalking to true
            animator.SetBool(isWalkingHash, true);
        }

        // if player doesnt press a key
        if (isWalking && !keyWalking)
        {
            // then set the isWalking to false
            animator.SetBool(isWalkingHash, false);
        }
        
        // Crouching
        if (keyCrouching)
        {
            animator.SetBool(isCrouchingHash, true);
        }
        if (!keyCrouching)
        {
            animator.SetBool(isCrouchingHash, false);
        }  
    

        

        
        //Jump
        if(Input.GetButtonDown("Jump"))
        {
           animator.SetTrigger("isJumping");
        }

        // --------FIGHT ANIMATIONS -------------------------
        //  KICK
        if (Input.GetKeyDown("h"))
        {
            animator.SetTrigger("MidKick");
        }
        //  PUNCH
        if (Input.GetKeyDown("j"))
        {
            animator.SetTrigger("StandingPunch");
        }
    }
}
