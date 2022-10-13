using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public delegate void GameAction();
    public event GameAction OnScoredEvent;

    new BoxCollider collider;

    AudioSource goalSound;

    protected virtual void Awake()
    {
        collider = GetComponent<BoxCollider>();
        goalSound = GetComponent<AudioSource>();
    }

    protected void Scored()
    {
        PlayGoalSound();
        OnScoredEvent?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PuckController>())
            Scored();
    }

    private void PlayGoalSound()
    {
        if (goalSound)
            goalSound.Play();
    }
}
