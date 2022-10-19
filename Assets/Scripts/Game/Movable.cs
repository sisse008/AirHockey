using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{

    public Transform originalPosition;
   
    public float speed = 8000f;
    public RuntimeInputHelper.InputType.InputTypeEnum inputType;

    protected bool canMove;
    protected virtual void Start()
    {
        canMove = true;
        if(inputType != RuntimeInputHelper.InputType.InputTypeEnum.None)
            RuntimeInputHelper.RegisterInputEvents(inputType , Move);
    }

    public void Freeze()
    {
        canMove = false;
    }
    public void Unfreeze()
    {
        canMove = true;
    }

    protected virtual void Move(float horizontal_axis, float vertical_axis)
    {
        if (canMove == false)
            return;

        Vector3 direction = new Vector3(horizontal_axis, vertical_axis, 0f).normalized;

        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

    public virtual void ResetPosition()
    {
        if (originalPosition == null)
            return;
        transform.position = originalPosition.position;
    }
}
