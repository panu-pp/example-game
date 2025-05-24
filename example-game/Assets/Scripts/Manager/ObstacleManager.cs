using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoSingleton<ObstacleManager>
{
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private Transform _parentTrans;

    [SerializeField] private float _obstacleSpeed = 1;
    [SerializeField] private float _obstacleInterval = 1;

    private float _elapsedTime = 0;
    private Coroutine _spwanObstacleCoroutine;

    public float ObstacleSpeed { get => _obstacleSpeed; set => _obstacleSpeed = value; }
    public float ObstacleInterval { get => _obstacleInterval; set => _obstacleInterval = value; }

    public void SpwanObstacle()
    {
        for (int i = _parentTrans.childCount - 1; i >= 0; i--)
        {
            Destroy(_parentTrans.GetChild(i).gameObject);
        }

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
}
