using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    public event EventHandler OnScoreUpdate;

    [SerializeField] private int _score = 0;

    public int Score { get => _score;}

    public void AddScore()
    {
        UpdateScore(_score + 1);
    }

    public void ResetScore()
    {
        UpdateScore(0);
    }

    private void UpdateScore(int score)
    {
        _score = score;
        OnScoreUpdate?.Invoke(this, EventArgs.Empty);
    }
}
