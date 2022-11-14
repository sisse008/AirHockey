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

    public PlayAreaController player1Area;
    public PlayAreaController player2Area;


    public Transform player1InitPosition;
    public Transform player2InitPosition;
    public Transform puckInitPosition;

    public DisplayController display;

    private static GameController instance = null;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameController>();
            return instance;
        }
    }

    private void Awake()
    {
        if (instance && instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        NewGame();
    }

    PlayerController InitNewPlayer(GameObject pad, Transform initPositionTransform, GoalController goal, ScoreboardController scoreboard, 
        PlayAreaController playArea, RuntimeInputHelper.InputType.InputTypeEnum inputType, bool isAI = false)
    {
        Quaternion q = Quaternion.identity;
        q.eulerAngles = new Vector3(270, 0, 0);

        GameObject player_go = Instantiate(pad, initPositionTransform.position, q);

        PlayerController player = Tools.GetComponent<PlayerController>(player_go);

        RigidBodyMovable rb;
        if(isAI == false)
            rb = Tools.GetComponent<RigidBodyMovable>(player_go);
        else
            rb = Tools.GetComponent<AIMovable>(player_go);

        rb.originalPosition = initPositionTransform;
        rb.inputType = inputType;

        player.InitializePlayer(goal, scoreboard, rb, playArea);
        player.OnScore += () => ResetGamePositions();

        return player;
    }
    void NewGame()
    {
        DestroyCurrentGame();

        if (Tools.IsMobile())
            InitMobileGamePlayers();
        else
            InitPCGamePlayers(GameManager.Instance.GameType == GameManager.GameTypeEnum.SINGLE_PLAYER); // if single player -> use AI

        Quaternion q = Quaternion.identity;
        q.eulerAngles = new Vector3(0,90,0);
        table = Instantiate(GameManager.Instance.hockeyTable, Vector3.zero, q);
        
        ResetGamePositions();
        scoreboard1.UpdateScoreBoard(0);
        scoreboard2.UpdateScoreBoard(0);
    }

    /// <summary>
    /// when useAI is set to true, there is only one player in the game. the second player is AI
    /// </summary>
    /// <param name="useAI"></param>
    private void InitPCGamePlayers(bool useAI = false)
    {
        //two player game
        player1 = InitNewPlayer(GameManager.Instance.pad1, player1InitPosition, goal1, scoreboard1, player1Area,
            RuntimeInputHelper.InputType.InputTypeEnum.Arrows); //first player uses arrow keys

        player2 = InitNewPlayer(GameManager.Instance.pad2, player2InitPosition, goal2, scoreboard2, player2Area,
          RuntimeInputHelper.InputType.InputTypeEnum.ASWD, useAI); //second player uses ASWD (unless useAI is true, then input type is meaningless)

    }
    private void InitMobileGamePlayers()
    {
        //mobile user player
        player1 = InitNewPlayer(GameManager.Instance.pad1, player1InitPosition, goal1, scoreboard1, player1Area,
          RuntimeInputHelper.InputType.InputTypeEnum.Touch);

        //AI player
        player2 = InitNewPlayer(GameManager.Instance.pad2, player2InitPosition, goal2, scoreboard2, player2Area,
          RuntimeInputHelper.InputType.InputTypeEnum.None, true);
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

    private void EndGame()
    {
        scoreboard1.UpdateScoreBoard(0);
        scoreboard2.UpdateScoreBoard(0);

        DestroyCurrentGame();
    }

    public void ExitGame()
    {
        EndGame();
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
        if(player1)
            player1.Freeze();
        if(player2)
            player2.Freeze();
        ResetGamePositions();
    }

    public void ResetGamePositions()
    {
        if(player1)
            player1.ResetPosition();
        if(player2)
            player2.ResetPosition();
        puck.transform.position = puckInitPosition.position;
        puck.Stop();
    }

   
}
