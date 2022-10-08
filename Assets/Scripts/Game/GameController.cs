using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerController player1;
    public PlayerController player2;
    public PuckController puck;

    private void OnEnable()
    {
        player1.myGoal.OnScoredEvent += ResetGamePositions;
        player2.myGoal.OnScoredEvent += ResetGamePositions;
    }
    private void OnDisable()
    {
        player1.myGoal.OnScoredEvent -= ResetGamePositions;
        player2.myGoal.OnScoredEvent -= ResetGamePositions;
    }

    private void ResetGamePositions()
    {
        player1.ResetPosition();
        player2.ResetPosition();
        puck.ResetPosition();
    }
}
