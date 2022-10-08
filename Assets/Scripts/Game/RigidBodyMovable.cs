using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMovable : Movable
{

    Rigidbody rb;
    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void Move(float horizontal_axis, float vertical_axis)
    {
        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;

        // rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        rb.AddForce(direction * speed);
    }

    public override void ResetPosition()
    {
        transform.position = originalPosition.position;
        rb.velocity = Vector3.zero;
    }
}
