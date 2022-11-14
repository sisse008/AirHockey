using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovable : RigidBodyMovable
{

    public float threshHoldDistance = 30f;

    private Vector3 InitPos;
    Vector3 newPos = new Vector3();

    protected override void Start()
    {
        InitPos = rb.position;
        StartCoroutine(AIMove());
    }

    private IEnumerator AIMove()
    {
        while (true)
        {
            yield return new WaitUntil(() => GameController.Instance.puck.isMoving);

            Vector3 puckPosition = GameController.Instance.puck.Position;
            //  Debug.Log("puckPosition:   " + puckPosition);
            // Debug.Log("AIPosition:    " +rb.position);
            //Debug.Log("(puckPosition - transform.position).magnitude:    " + (puckPosition - transform.position).magnitude);

            if (Vector3.Distance(puckPosition, rb.position) < threshHoldDistance && puckPosition.z < rb.position.z)
            {
                newPos = InitPos;
                newPos.x = puckPosition.x;
                yield return AIMoveToPosition(newPos, 0.5f);
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
}
