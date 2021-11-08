using System.Collections;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
    private Rigidbody rb;
    private Transform tr;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Burger(Clone)")
        {
            Destroy(collision.gameObject);
            tr.localScale += scaleChange;
            rb.mass += 10;
        }
    }
}