using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private Transform _parentTrans;

    private float _elapsedTime = 0; 

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= GameManager.Instance.ObstacleInterval)
        {
            Instantiate(_obstaclePrefab, _parentTrans);
            _elapsedTime = 0;
        }
    }
}
