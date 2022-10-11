using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{

    public Transform originalPosition;
   
    public float speed = 8000f;
    public RuntimeInputHelper.InputType.InputTypeEnum inputType;
  
    private void Start()
    {
        if(inputType != RuntimeInputHelper.InputType.InputTypeEnum.None)
            RuntimeInputHelper.RegisterInputEvents(inputType , Move);
    }

    protected virtual void Move(float horizontal_axis, float vertical_axis)
    {
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
