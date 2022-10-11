using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    public Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

}
