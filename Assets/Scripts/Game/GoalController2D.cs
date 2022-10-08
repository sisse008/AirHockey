using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class GoalController2D : GoalController
{

    new BoxCollider2D collider2D;

    protected override void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PuckController>())
            Scored();
    }
}
