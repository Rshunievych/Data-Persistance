using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardEntryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _entryNameText;
    [SerializeField] private TMP_Text _entryScoreText;

    public void Initialized(ScoreboardEntry scoreboardEntry)
    {
        _entryNameText.text = scoreboardEntry.EntryName;
        _entryScoreText.text = scoreboardEntry.EntryScore.ToString();
    }
}
