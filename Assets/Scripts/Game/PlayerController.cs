using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    public GoalController myGoal;
    public ScoreboardController myScoreboard;
    public PlayAreaController myPlayArea;


    RigidBodyMovable movableRigidBody;

    [SerializeField]
    protected int score;
    public int Score => score;

    public UnityAction OnScore;


    public void Freeze()
    {
        movableRigidBody.Freeze();
    }
    public void Unfreeze()
    {
        movableRigidBody.Unfreeze();
    }
    public void InitializePlayer(GoalController myGoal, ScoreboardController myScoreboard, RigidBodyMovable movableRigidBody, PlayAreaController playArea)
    {
        this.myGoal = myGoal;
        this.myScoreboard = myScoreboard;
        this.movableRigidBody = movableRigidBody;
        this.myPlayArea = playArea;

        myGoal.OnScoredEvent += () =>
        {
            score++;
            if (myScoreboard)
                myScoreboard.UpdateScoreBoard(score);

            OnScore?.Invoke();
        };
    }

    public void ResetPosition()
    {
        movableRigidBody.ResetPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsTriggerCollisionWithPlayArea(other))
        {
            myPlayArea.PropmptWarning(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (IsTriggerCollisionWithPlayArea(other))
        {
            myPlayArea.PropmptWarning();
        }
    }

    bool IsTriggerCollisionWithPlayArea(Collider other)
    {
        PlayAreaController playArea = other.GetComponent<PlayAreaController>();
        if (playArea && playArea == myPlayArea)
            return true;
        return false;
    }

}
