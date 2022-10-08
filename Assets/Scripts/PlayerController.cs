using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : RigidBodyMovable
{

    public GoalController myGoal;
    public ScoreboardController myScoreboard;

    [SerializeField]
    private int score;
    public int Score => score;

    private void OnEnable()
    {
        myGoal.OnScoredEvent += () => 
        {
            score++;
            myScoreboard.UpdateScoreBoard(score);
        };
    }

   
}
