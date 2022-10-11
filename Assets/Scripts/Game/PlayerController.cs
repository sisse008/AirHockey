using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RigidBodyMovable))]
public class PlayerController : MonoBehaviour
{

    public GoalController myGoal;
    public ScoreboardController myScoreboard;
    
    
    Movable movableRigidBody;

    [SerializeField]
    private int score;
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
    public void InitializePlayer(GoalController myGoal, ScoreboardController myScoreboard, Movable movableRigidBody)
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
