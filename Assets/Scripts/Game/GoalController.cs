using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public delegate void GameAction();
    public event GameAction OnScoredEvent;

    new BoxCollider collider;

    protected virtual void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    protected void Scored()
    {
        OnScoredEvent?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PuckController>())
            Scored();
    }
}
