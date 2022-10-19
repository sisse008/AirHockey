using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{

    public GoalController myGoal;
    public ScoreboardController myScoreboard;


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
    public void InitializePlayer(GoalController myGoal, ScoreboardController myScoreboard, RigidBodyMovable movableRigidBody)
    {
        this.myGoal = myGoal;
        this.myScoreboard = myScoreboard;
        this.movableRigidBody = movableRigidBody;

        myGoal.OnScoredEvent += () =>
        {
            score++;
            if (myScoreboard)
                myScoreboard.UpdateScoreBoard(score);

            OnScore?.Invoke();
        };
    }

    private void OnDisable()
    {
      /*  foreach (Delegate d in OnScore.GetInvocationList())
        {
            OnScore -= (UnityAction)d;
        }
      */
    }

    public void ResetPosition()
    {
        movableRigidBody.ResetPosition();
    }



}
