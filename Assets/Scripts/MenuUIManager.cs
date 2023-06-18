using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_InputField _playerNameInputField;

    private void Start()
    {
        GameMaster.playerName = "";
        GameMaster.playerScore = 0;
    }
    public void StartNewGame()
    {
        string name;
        if (_playerNameInputField.text.Length > 0)
            name = _playerNameInputField.text;
        else
            name = "Anonimus";
        GameMaster.playerName = name;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
