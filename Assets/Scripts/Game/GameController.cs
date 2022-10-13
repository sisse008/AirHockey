using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerController player1;
    public PlayerController player2;
    public PuckController puck;
    public GameObject table;

    public GoalController goal1;
    public GoalController goal2;

    public ScoreboardController scoreboard1;
    public ScoreboardController scoreboard2;


    public Transform player1InitPosition;
    public Transform player2InitPosition;
    public Transform puckInitPosition;

    public DisplayController display;


    private void Start()
    {
        NewGame();
    }

    PlayerController InitNewPlayer(GameObject pad, Transform initPositionTransform, GoalController goal, ScoreboardController scoreboard,
        RuntimeInputHelper.InputType.InputTypeEnum inputType)
    {

        Quaternion q = Quaternion.identity;
        q.eulerAngles = new Vector3(270, 0, 0);

        GameObject player_go = Instantiate(pad, initPositionTransform.position, q);
        PlayerController player = player_go.GetComponent<PlayerController>();
        if (player == null)
            player = player_go.AddComponent<PlayerController>();

        RigidBodyMovable rb = player_go.GetComponent<RigidBodyMovable>();
        if (rb == null)
            rb = player_go.AddComponent<RigidBodyMovable>();
        rb.originalPosition = initPositionTransform;
        rb.inputType = inputType;


        player.InitializePlayer(goal, scoreboard, rb);
        player.OnScore += () => ResetGamePositions();

        return player;
    }
    void NewGame()
    {

        DestroyCurrentGame();

        player1 = InitNewPlayer(GameManager.Instance.pad1, player1InitPosition, goal1, scoreboard1,
            RuntimeInputHelper.InputType.InputTypeEnum.Arrows);


        player2 = InitNewPlayer(GameManager.Instance.pad2, player2InitPosition, goal2, scoreboard2,
          RuntimeInputHelper.InputType.InputTypeEnum.ASWD);
       
        Quaternion q = Quaternion.identity;
        q.eulerAngles = new Vector3(0,90,0);
        table = Instantiate(GameManager.Instance.hockeyTable, Vector3.zero, q);
        
        ResetGamePositions();
        scoreboard1.UpdateScoreBoard(0);
        scoreboard2.UpdateScoreBoard(0);
    }

    void DestroyCurrentGame()
    {
        if (player1 != null)
            Destroy(player1.gameObject);

        if (player2 != null)
            Destroy(player2.gameObject);

        if (table != null)
            Destroy(table.gameObject);

    }

    public void EndGame()
    {
        scoreboard1.UpdateScoreBoard(0);
        scoreboard2.UpdateScoreBoard(0);

        DestroyCurrentGame();

        GameManager.Instance.SwitchToMainMenuScene(0);
    }

    IEnumerator DisplayGoalVideo()
    {
        PauseGame();
        yield return display.ShowVideo();
        UnpauseGame();
    }

    void UnpauseGame()
    {
        player1.Unfreeze();
        player2.Unfreeze();
    }
    void PauseGame()
    {
        //disable input
        player1.Freeze();
        player2.Freeze();
        ResetGamePositions();
    }

    public void ResetGamePositions()
    {
        player1.ResetPosition();
        player2.ResetPosition();
        puck.transform.position = puckInitPosition.position;
        puck.Stop();
    }

   
}
