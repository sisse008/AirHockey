using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovable : RigidBodyMovable
{
    protected override void Start()
    {
        canMove = false;
    }

    Vector2 NextPosition()
    {
        return Vector2.zero;
    }

    private void Update()
    {
        Vector2 nextPos = NextPosition();
        Move(nextPos.x, nextPos.y);
    }
}
