using System.Collections;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.0f, 0.2f, 0.0f);
    private Rigidbody rb;
    private Transform tr;
    private PlayerMovement pm;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        pm = GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Burger(Clone)")
        {
            Destroy(collision.gameObject);
            tr.localScale += scaleChange;
            rb.mass += 10;
            pm.movementSpeed -= 1;
            pm.rotationSpeed *=0.95f;
        }
    }
}