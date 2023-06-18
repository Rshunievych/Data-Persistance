using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static string playerName;
    public static int playerScore;
    [SerializeField] Scoreboard _scoreboard;
    [SerializeField] bool _isInGame;

    private void Start()
    {
        if (_isInGame)
            MainManager.OnGameOver += DisplayHighscore;
    }
    private void OnDisable()
    {
        if (_isInGame)
            MainManager.OnGameOver -= DisplayHighscore;
    }
    private void DisplayHighscore(int points)
    {
        _scoreboard.gameObject.SetActive(true);
        _scoreboard.AddEntry(new ScoreboardEntry(playerName, points));
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
