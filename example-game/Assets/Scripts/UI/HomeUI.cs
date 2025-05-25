using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeUI : MonoSingleton<HomeUI>
{
    [SerializeField] private Button _startButton;

    [Header("SCORE")]
    [SerializeField] private GameObject _scoreObj;
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    private void Start()
    {
        _startButton.onClick.AddListener(OnStart);
        ScoreManager.Instance.OnScoreUpdate += OnScoreUpdate;

        _scoreTMP.text = "0";
    }
    private void OnDestroy()
    {
        _startButton.onClick.RemoveAllListeners();
        ScoreManager.Instance.OnScoreUpdate -= OnScoreUpdate;
    }

    private void OnStart()
    {
        StateManager.Instance.SwitchState(StateManager.GameState.Play);
    }

    public void ToggleHomeUI(bool isActive)
    {
        _startButton.gameObject.SetActive(isActive);
    }

    private void OnScoreUpdate(object sender, EventArgs e)
    {
        _scoreTMP.text = ScoreManager.Instance.Score.ToString().Trim();
    }
}
