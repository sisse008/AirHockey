using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class GoalController : MonoBehaviour
{

    new BoxCollider2D collider;

    public delegate void GameAction();
    public event GameAction OnScoredEvent;


    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PuckController>())
            OnScoredEvent?.Invoke();
    }
}
