using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovable : RigidBodyMovable
{

    public float threshHoldPuckDistance = 30f;
    public float maxSpeed = 20f;

    private Vector3 InitPos;
    Vector3 targetPosition = new Vector3();
    float targetSpeed;

    protected override void Start()
    {
        InitPos = rb.position;
       // StartCoroutine(AIMove()); obselete
    }

    private void FixedUpdate()
    {
        if (GameController.Instance.puck.isMoving == false)
            return;

        if (movementBounderies == null)
            return;

        //if puck is far, move slowly and only on x axis
        if (GameController.Instance.puck.Position.z < movementBounderies.MinZ)
        {
            Debug.Log("Far");
            targetSpeed = maxSpeed * Random.Range(0.1f, 0.3f);
            targetPosition = InitPos;
            targetPosition.x = GameController.Instance.puck.Position.x;
        }
        else //puck is near, move directly to the puck
        {
            Debug.Log("Near");
            targetSpeed = Random.Range(maxSpeed * 0.4f, maxSpeed);
            targetPosition = InitPos;
            targetPosition.x = GameController.Instance.puck.Position.x;
            targetPosition.z = GameController.Instance.puck.Position.z;
        }
        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, 
            targetSpeed* Time.fixedDeltaTime));
    }

    #region obselete AI movement code
    private IEnumerator AIMove()
    {
        while (true)
        {
            yield return new WaitUntil(() => GameController.Instance.puck.isMoving);

            Vector3 puckPosition = GameController.Instance.puck.Position;
            //  Debug.Log("puckPosition:   " + puckPosition);
            // Debug.Log("AIPosition:    " +rb.position);
            //Debug.Log("(puckPosition - transform.position).magnitude:    " + (puckPosition - transform.position).magnitude);

            if (Vector3.Distance(puckPosition, rb.position) < threshHoldPuckDistance && puckPosition.z < rb.position.z)
            {
                targetPosition = InitPos;
                targetPosition.x = puckPosition.x;
                yield return AIMoveToPosition(targetPosition, 0.5f);
            }
        }
    }  
    protected IEnumerator AIMoveToPosition(Vector3 destination, float actionTime)
    {
        float time = 0;
        Vector3 currentPosition = rb.position;
       
        while (time < actionTime)
        {
            if (canMove == false)
                yield break;
            time += Time.deltaTime;
            rb.position = Vector3.Lerp(currentPosition, destination, time / actionTime);
            yield return null;
        }
    }
    #endregion
}
