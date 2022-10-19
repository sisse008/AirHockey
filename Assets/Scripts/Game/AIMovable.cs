using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovable : RigidBodyMovable
{
   
    protected override void Start()
    {
        canMove = true;
        //TODO
        //register MOVE to event that puck moves
    }

    //TODO
    Vector2 currentPos = new Vector2();
    protected override void MoveInDirection(float horizontal_axis, float vertical_axis)
    {
        //use puck position to calculate my next position

        //  Vector2 nextPos = NextPosition();

        //get direction to move

        // currentPos.x = transform.position.x;
        //  currentPos.y = transform.position.z;
        // Vector2 direction = nextPos - currentPos;

        //call base move with direction cordinates

        //base.Move(direction.x, direction.y);

    }

}
