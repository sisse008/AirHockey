using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMovable : Movable
{

    protected Rigidbody rb;
    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void MoveToPosition(float newPos_x, float newPos_z)
    {
        if (canMove == false)
            return;

        Vector3 direction = new Vector3(newPos_x, transform.position.y, newPos_z) - transform.position;

        float distance = direction.magnitude;
        if(distance > 0.5f)
            MoveInDirection(direction.x, direction.z);
    }
    protected override void MoveInDirection(float horizontal_axis, float vertical_axis)
    {
        if (canMove == false)
            return;

        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;
        rb.AddForce(direction * speed);
    }

    public override void ResetPosition()
    {
        transform.position = originalPosition.position;
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        rb.velocity = Vector3.zero;
        bool _canMove = canMove;
        canMove = false;
        yield return new WaitForSeconds(0.1f);
        canMove = _canMove;
    }
}
