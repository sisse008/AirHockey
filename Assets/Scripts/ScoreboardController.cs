using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardController : MonoBehaviour
{
    public TMPro.TMP_Text t_score;

    public void UpdateScoreBoard(int score)
    {
        t_score.text = score.ToString();
    }
}
