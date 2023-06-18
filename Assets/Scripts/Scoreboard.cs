using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private int _maxScoreboardEntries = 20;
    [SerializeField] private Transform _highscoresHolderTransform;
    [SerializeField] private GameObject _scoreboardEntryObject;
    [SerializeField] private GameObject _noScoresMesage;

    public void DisplayScoreboard()
    {
        ScoreboardSaveData savedScores = GetSavedScores();
        if (savedScores != null)
            UpdateUI(savedScores);
        else
        {
            _noScoresMesage.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private ScoreboardSaveData GetSavedScores()
    {
        string json = PlayerPrefs.GetString("Scoreboard");
        return JsonUtility.FromJson<ScoreboardSaveData>(json);
    }

    private void SaveScoreboard(ScoreboardSaveData scoreboardSaveData)
    {
        string json = JsonUtility.ToJson(scoreboardSaveData, true);
        PlayerPrefs.SetString("Scoreboard", json);
    }

    public void ResetScores()
    {
        PlayerPrefs.DeleteKey("Scoreboard");
    }

    private void UpdateUI(ScoreboardSaveData scoreboardSaveData)
    {
        foreach (Transform child in _highscoresHolderTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (ScoreboardEntry scoreboardEntry in scoreboardSaveData.HighScores)
        {
            Instantiate(_scoreboardEntryObject, _highscoresHolderTransform).
                GetComponent<ScoreboardEntryUI>().Initialized(scoreboardEntry);
        }
    }

    public void AddEntry(ScoreboardEntry scoreboardEntry)
    {
        ScoreboardSaveData savedScores = GetSavedScores();

        if (savedScores != null)
        {
            bool scoreAdded = false;

            for (int i = 0; i < savedScores.HighScores.Count; i++)
            {
                if (scoreboardEntry.EntryScore > savedScores.HighScores[i].EntryScore)
                {
                    savedScores.HighScores.Insert(i, scoreboardEntry);
                    scoreAdded = true;
                    break;
                }
            }

            if (!scoreAdded && savedScores.HighScores.Count < _maxScoreboardEntries)
                savedScores.HighScores.Add(scoreboardEntry);

            if (savedScores.HighScores.Count > _maxScoreboardEntries)
                savedScores.HighScores.RemoveAt(_maxScoreboardEntries);
        }
        else
        {
            savedScores = new ScoreboardSaveData();
            savedScores.HighScores.Add(scoreboardEntry);
        }

        UpdateUI(savedScores);
        SaveScoreboard(savedScores);
    }
}
