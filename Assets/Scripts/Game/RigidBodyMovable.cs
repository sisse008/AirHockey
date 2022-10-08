using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovable : Movable
{
    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected override void Move(float horizontal_axis, float vertical_axis)
    {
        Vector2 direction = new Vector3(horizontal_axis, vertical_axis).normalized;

        rb.MovePosition(rb.position + direction*speed*Time.deltaTime);
    }

    public override void ResetPosition()
    {
        transform.position = originalPosition.position;
        rb.velocity = Vector2.zero;
    }
}
