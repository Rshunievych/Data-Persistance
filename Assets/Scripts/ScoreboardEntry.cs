using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ScoreboardEntry
{
    public string EntryName;
    public int EntryScore;

    public ScoreboardEntry(string name, int score)
    {
        EntryName = name;
        EntryScore = score;
    }
}
