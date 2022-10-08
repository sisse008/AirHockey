using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Movable))]
public class PlayerController : MonoBehaviour
{

    public GoalController myGoal;
    public ScoreboardController myScoreboard;
    
    
    Movable movableRigidBody;

    [SerializeField]
    private int score;
    public int Score => score;


    private void Awake()
    {
        movableRigidBody = GetComponent<Movable>();
    }
    private void OnEnable()
    {
        myGoal.OnScoredEvent += () => 
        {
            score++;
            if(myScoreboard)
                myScoreboard.UpdateScoreBoard(score);
        };
    }

    public void ResetPosition()
    {
        
    }



}
