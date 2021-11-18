using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimePrefab : MonoBehaviour
{
    public float timeToLive = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}
