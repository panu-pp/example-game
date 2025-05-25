using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoSingleton<ObstacleManager>
{
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private Transform _parentTrans;

    private float _obstacleSpeed = 1;
    private float _obstacleInterval = 5;

    private float _elapsedTime = 0;
    private Coroutine _spwanObstacleCoroutine;

    public float ObstacleSpeed { get => _obstacleSpeed; }
    
    private void Start()
    {
        ScoreManager.Instance.OnScoreUpdate += OnScoreUpdate;
    }
    private void OnDestroy()
    {
        ScoreManager.Instance.OnScoreUpdate -= OnScoreUpdate;
    }

    public void SpwanObstacle()
    {
        if (_spwanObstacleCoroutine != null)
        {
            StopCoroutine(_spwanObstacleCoroutine);
            _spwanObstacleCoroutine = null;
        }

        _spwanObstacleCoroutine = StartCoroutine(SpawnObstacleCoroutine());
    }

    private IEnumerator SpawnObstacleCoroutine()
    {
        _elapsedTime = _obstacleInterval;

        while (StateManager.Instance.gameState == StateManager.GameState.Play)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _obstacleInterval)
            {
                var obstacle = Instantiate(_obstaclePrefab, _parentTrans);
                obstacle.Init();
                _elapsedTime = 0;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void ResetObstacle()
    {
        _obstacleSpeed = GameManager.Instance.ObstacleSpeed;
        _obstacleInterval = GameManager.Instance.ObstacleInterval;

        for (int i = _parentTrans.childCount - 1; i >= 0; i--)
        {
            Destroy(_parentTrans.GetChild(i).gameObject);
        }
    }

    private void OnScoreUpdate(object sender, EventArgs e)
    {
        int score = ScoreManager.Instance.Score;
        if (score >= 5 && score % 5 == 0)
        {
            _obstacleSpeed += 0.5f;
            _obstacleInterval = Mathf.Max(1, _obstacleInterval - 0.5f);
            Debug.Log($"SPEED UP: {_obstacleSpeed}");
            Debug.Log($"INTERVAL DOWN: {_obstacleInterval}");
        }
    }
}
